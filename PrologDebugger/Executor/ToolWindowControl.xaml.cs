//------------------------------------------------------------------------------
// <copyright file="ToolWindowControl.xaml.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EnvDTE;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Prolog;
using Prolog.Code;

namespace PrologDebugger.Executor
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for ToolWindowControl.
    /// </summary>
    public partial class ToolWindowControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToolWindowControl"/> class.
        /// </summary>
        public ToolWindowControl()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles click on the button by displaying a message box.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            var plproj = GetCurrentPrologProject();
            if (plproj == null)
            {
                MessageBox.Show("Текущий проект не plproj");
                return;
            }
            var programStr = GetProgram(plproj);
            ExecutePrologProgram(programStr);
        }

        private void ExecutePrologProgram(string programStr)
        {
            var lines = programStr.Split(Environment.NewLine.ToCharArray());
            var codeSentences = new List<CodeSentence>();
            foreach (var line in lines)
            {
                codeSentences.AddRange(Prolog.Parser.Parse(line));
            }
            Prolog.Program program = new Prolog.Program();
            foreach (var codeSentence in codeSentences)
            {
                program.Add(codeSentence);
            }
            var qw = Parser.Parse($":-{QueryTextBox.Text}");
            Query query = new Query(qw[0]);
            PrologMachine machine = PrologMachine.Create(program, query);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(machine.RunToSuccess().ToString());
            if (machine.QueryResults != null)
            {
                foreach (var v in machine.QueryResults.Variables)
                {
                    sb.AppendLine($"{v.Name} = {v.Text}");
                }
            }

            //if (machine.StackFrames != null)
            //{
            //    foreach (var v in machine.StackFrames)
            //    {
            //        sb.AppendLine(v.ToString());
            //    }
            //}
            ResultTextBox.Text = sb.ToString();
        }

        private static string GetProgram(Project plproj)
        {
            var currentDirectory = Path.GetDirectoryName(plproj.FullName);
            string[] files = Directory.GetFiles(currentDirectory, "*.pl");
            var result = new StringBuilder();
            foreach (var file in files)
            {
                result.AppendLine(File.ReadAllText(file));
            }
            return result.ToString();
        }

        private Project GetCurrentPrologProject()
        {
            IVsSolution solution = (IVsSolution)Package.GetGlobalService(typeof(IVsSolution));
            return GetProjectsInSolution(solution).Select(GetDTEProject).FirstOrDefault(x => x.FileName.EndsWith("plproj"));
        }

        private static IVsHierarchy[] GetProjectsInSolution(IVsSolution solution)
        {
            return GetProjectsInSolution(solution, __VSENUMPROJFLAGS.EPF_LOADEDINSOLUTION);
        }

        private static IVsHierarchy[] GetProjectsInSolution(IVsSolution solution, __VSENUMPROJFLAGS flags)
        {
            var resutl = new List<IVsHierarchy>();
            if (solution == null)
                return resutl.ToArray();

            IEnumHierarchies enumHierarchies;
            Guid guid = Guid.Empty;
            solution.GetProjectEnum((uint)flags, ref guid, out enumHierarchies);
            if (enumHierarchies == null)
                return resutl.ToArray();

            IVsHierarchy[] hierarchy = new IVsHierarchy[1];
            uint fetched;
            while (enumHierarchies.Next(1, hierarchy, out fetched) == VSConstants.S_OK && fetched == 1)
            {
                if (hierarchy.Length > 0 && hierarchy[0] != null)
                    resutl.Add(hierarchy[0]);
            }
            return resutl.ToArray();
        }

        private static Project GetDTEProject(IVsHierarchy hierarchy)
        {
            if (hierarchy == null)
                throw new ArgumentNullException("hierarchy");

            object obj;
            hierarchy.GetProperty(VSConstants.VSITEMID_ROOT, (int)__VSHPROPID.VSHPROPID_ExtObject, out obj);
            return obj as Project;
        }
    }
}