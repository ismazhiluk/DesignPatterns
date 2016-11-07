namespace Decorator.Client
{
    public class ClientBuilder
    {
        private IClient _client;

        public ClientBuilder(IClient client)
        {
            _client = client;
        }

        public ClientBuilder WithHideName()
        {
            _client = new HideNameClient(_client);
            return this;
        }

        public ClientBuilder WithEncryptedMessage()
        {
            _client = new EncryptedMessageClient(_client);
            return this;
        }

        public IClient Build()
        {
            return _client;
        }
    }
}
