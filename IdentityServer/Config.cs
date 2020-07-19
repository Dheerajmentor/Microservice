// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        private const string SampleAPI_Secret = "tT1CCYyY7P";
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            { 
                new ApiScope("sampleapi.read","Read your data"),
                new ApiScope("sampleapi.write","Write your data"),
                new ApiScope("sampleapi.delete","Delete your data")
            };

        public static IEnumerable<ApiResource> ApiResources =>
             new List<ApiResource>
            {
                new ApiResource("sampleAPI", "Sample API"){
                    Scopes = { "sampleapi.read", "sampleapi.write", "sampleapi.delete" },
                }
            };
        

        public static IEnumerable<Client> Clients =>
            new Client[] 
            {
                new Client(){ 
                    ClientId = "MS.UI",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    AllowOfflineAccess = true,
                    ClientSecrets = { new Secret("z71C0PyDjR".Sha256()) },
                    RedirectUris ={"http://localhost:5003/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:5003"},
                    FrontChannelLogoutUri = "http://localhost:5003/signout-oidc",
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "sampleapi.read"
                    },
                },
            
            };
    }
}