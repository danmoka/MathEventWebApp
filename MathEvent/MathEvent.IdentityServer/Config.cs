﻿using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    /// <summary>
    /// Статический класс конфигурации для IdentityServer4
    /// </summary>
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("matheventapi", "Math Event API")
            };

        /// <summary>
        /// Описывает клиентов, которые могут взаимодействовать с IdentityServer4
        /// </summary>
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    // TODO: сделать начитку из json
                    ClientId = "react_spa",
                    ClientName = "React SPA",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowAccessTokensViaBrowser = true,
                    AccessTokenLifetime = 3600,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "matheventapi"
                    }
                }
            };
    }
}