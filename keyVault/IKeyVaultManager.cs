namespace azurecSharpDemo.keyVault
{
    public interface IKeyVaultManager
    {
        public Task<string> GetSecret(string secretName);
    }
}
