# .NET Core DataProtection

Dans certaines de vos applications, il peut être nécessaire de devoir encrypter des données sensibles, passées en query parameter, comme des identifiants, des tokens et bien d'autres.

Nous allons utiliser pour ça un mécanisme tout à fait standard et built-in en .NET Core nommé ``DataProtection``.

L'idée est que le serveur renverra au client cette donnée encryptée, grâce à un ``IDataProtector``. Cette variable encryptée aura une durée de vie que vous aurez vous même définie. Passé ce délai, la variable ne pourra plus être décryptée, ceci limite donc considérablement le bruteforce.

Vous pourrez instancier autant de ``DataProtector`` que vous le souhaitez, avec leur propre scope. Chaque donnée encryptée au moyen d'un ``DataProtector`` A, devra être décryptée via cette même instance. Décrypter cette variable avec un  ``DataProtector`` B vous mènera à une exception.

Les clés utilisées pour l'encryption et la décryption sont persistées sur le filesystem. Par défaut, elles y sont stockées de manière décryptée, mais vous pouvez tout à fait corriger ceci en utilisant ``ProtectKeysWithDpapi``.

# Documentation

* [Configure ASP.NET Core Data Protection - docs.microsoft.com](https://docs.microsoft.com/en-us/aspnet/core/security/data-protection/configuration/overview?view=aspnetcore-6.0)
* [Protecting Data with IDataProtector in ASP.NET Core - code-maze.com](https://code-maze.com/data-protection-aspnet-core/)
* [DataProtectionBuilderExtensions Class - docs.microsoft.com](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.dataprotection.dataprotectionbuilderextensions?view=aspnetcore-6.0)