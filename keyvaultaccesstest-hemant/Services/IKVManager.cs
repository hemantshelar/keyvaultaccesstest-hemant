using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace keyvaultaccesstest_hemant.Services;
public interface IKVManager
{
	string GetSecret(string secretName);
}

public class KVManager : IKVManager
{
	public string GetSecret(string secretName)
	{
		var kvUri = "https://scripttestkvhf.vault.azure.net/";
		var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
		KeyVaultSecret secret = client.GetSecret(secretName);
		return secret.Value;
	}
}
