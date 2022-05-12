using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace News.Identity
{
    public static class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("NewsWebApi", "Web Api")
            };

        //Arrea that helps client app to know info about user.
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(), new IdentityResources.Profile()
            };

        //Arrea that helps client app to know secure info about application.
        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("NewsWebApi", "Web Api", new[] {JwtClaimTypes.Name})
                {
                    Scopes = {"NewsWebApi"}
                }
            };

        public static IEnumerable<Client> ClientApps =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "news-web-api-client",
                    ClientName = "News Web",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RedirectUris = {//TODO: add uris
                        "http://[news-web-api-client-URI]/signin-oidc"
                    },
                    AllowedCorsOrigins =
                    {
                        "http://[uris-have-access-to-identityserver]"
                    },
                    PostLogoutRedirectUris = {
                        "http://[news-web-api-client-URI]/signout-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "NewsWebApi"
                    },
                    AllowAccessTokensViaBrowser = true,
                }
            };
    }
}
