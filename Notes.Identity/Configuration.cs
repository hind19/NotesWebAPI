using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace Notes.Identity
{
    public static class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("NotesWebAPI", "Web API")
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),

            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("NotesWebAPI", "Web API", new [] { JwtClaimTypes.Name})
                {
                    Scopes = {"NotesWebAPI"}
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "notes-web-api",
                    ClientName = "Notes Web",
                    AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                    RequireClientSecret = false,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    RedirectUris =
                    {
                        //we have no client yet. So, the code mask is entered below.
                        "https://localhost:7066/index.html"
                    },
                    AllowedCorsOrigins = 
                    {
                         "https://localhost:7066"
                    },
                    PostLogoutRedirectUris =
                    {
                        //we have no client yet. So, the code mask is entered below.
                        "https://localhost:7066/index.html"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "NotesWebAPI"
                    },
                    AllowAccessTokensViaBrowser = true,
                }
            };
    }   
}
