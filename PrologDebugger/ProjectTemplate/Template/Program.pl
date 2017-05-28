﻿% Команды для компиляции и запуска
%
% Проверено с GNU Prolog 1.3.1
%
% # gplc --no-top-level gcd.pro
% # ./gcd 22 33 44 121


% Первое число, второе число, НОД

% Верно, что НОД (A, 0) = A
gcd2(A, 0, A).

% Верно, что НОД(A, B) = G,
% когда A>0, B>0 и НОД(B, A % B) = G (% - остаток от деления)
gcd2(A, B, G) :- A>0, B>0, N is mod(A, B), gcd2(B, N, G).

gcdn(A, [], A).
gcdn(A, [B|Bs], G) :- gcd2(A, B, N), gcdn(N, Bs, G).
gcdn([A|As], G) :- gcdn(A, As, G).