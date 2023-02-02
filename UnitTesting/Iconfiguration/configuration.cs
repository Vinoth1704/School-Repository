using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

public class TestConfiguration : IConfiguration
{
    public string? this[string key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public IEnumerable<IConfigurationSection> GetChildren()
    {
        throw new NotImplementedException();
    }

    public IChangeToken GetReloadToken()
    {
        throw new NotImplementedException();
    }

    public IConfigurationSection GetSection(string key)
    {
        return new TestConfigurationSection();
    }
    public class TestConfigurationSection : IConfigurationSection
    {
        public string? this[string key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Value
        {
            get { return "1"; }
        }

        public string Key => throw new NotImplementedException();

        public string Path => throw new NotImplementedException();

        string? IConfigurationSection.Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IEnumerable<IConfigurationSection> GetChildren()
        {
            throw new NotImplementedException();
        }

        public IChangeToken GetReloadToken()
        {
            throw new NotImplementedException();
        }

        public IConfigurationSection GetSection(string key)
        {
            throw new NotImplementedException();
        }
    }
}


