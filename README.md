## Ways to access KeyVault

- Using by configuring Environment variable with key-vault reference 

`` "TESTENV": "@Microsoft.KeyVault(SecretUri=https://scripttestkvhf.vault.azure.net/secrets/envsecret/d428e61371ab48f0be6dda925d83d71c/)"``

- Using `SecretClient` library and `DefaultAzureCredential`

```	public string GetSecret(string secretName)
	{
		var kvUri = "https://scripttestkvhf.vault.azure.net/";
		var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
		KeyVaultSecret secret = client.GetSecret(secretName);
		return secret.Value;
	}
```
- Using Entra ID app registrtion


