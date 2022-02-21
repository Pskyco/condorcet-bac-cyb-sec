**Instal IS4 Templates**
``dotnet new -i identityserver4.templates``

**create basic API with 'webapi' template and name it 'MyApi'**
``dotnet new webapi -n MyApi``

**create empty sln named 'IS4Samples'**
``dotnet new sln -n IS4Samples``

**add 'IdentityServer' project to our newly created solution**
``dotnet sln add .\src\IdentityServer\IdentityServer.csproj``

**to run a project with .NET CLI, place yourself in .csproj folder**
``dotnet run``