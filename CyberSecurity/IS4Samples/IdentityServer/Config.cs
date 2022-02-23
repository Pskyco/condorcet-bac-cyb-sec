// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityModel;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                //new IdentityResources.Profile()
                new IdentityResource(
                    name: "profile",
                    displayName: "your custom profile data",
                    userClaims: new List<string>()
                    {
                        JwtClaimTypes.Name,
                        JwtClaimTypes.Address,
                        JwtClaimTypes.WebSite,
                    })
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("myApi", "My API"),
                new ApiScope("myApi2", "My API 2"),
                new ApiScope("myApi3", "My API 3")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client()
                {
                    ClientId = "myConsole",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret>()
                    {
                        new Secret("mySecret".Sha256())
                    },
                    AllowedScopes = new List<string>()
                    {
                        "myApi",
                        "myApi2",
                    }
                },
                new Client()
                {
                    ClientId = "myMvc",
                    AllowedGrantTypes = GrantTypes.Code,
                    ClientSecrets = new List<Secret>()
                    {
                        new Secret("myMvcSecret".Sha256())
                    },
                    AllowedScopes = new List<string>()
                    {
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OpenId,
                        "myApi"
                    },
                    AllowOfflineAccess = true,
                    PostLogoutRedirectUris = { "https://localhost:7235/signout-callback-oidc" },
                    RedirectUris = { "https://localhost:7235/signin-oidc" }
                },
                new Client()
                {
                    ClientId = "mySwagger",
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes = new List<string>()
                    {
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OpenId,
                        "myApi"
                    },
                    RequirePkce = true,
                    RequireClientSecret = false,
                    RedirectUris = { "https://localhost:6001/swagger/oauth2-redirect.html" },
                    AllowedCorsOrigins = { "https://localhost:6001" }
                },
            };
    }
}