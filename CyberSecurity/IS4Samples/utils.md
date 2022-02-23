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

**add IS4 default view to IdentityServer project (place yourself in IdentityServer folder)**
``dotnet new is4ui``

**create basic API with 'webapi' template and name it 'MyApi'**
``dotnet new webapi -n MyApi``

**create basic MVC with 'mvc' template and name it 'MyMvc'**
``dotnet new mvc -n MyMvc``

**create IdentityServer4 with Entity Framweork using 'is4ef' template and name it 'IdentityServerEf'**
``dotnet new is4ef -n IdentityServerEf``