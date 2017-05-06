namespace Meetup.Security.Entities
{
    public static class DbInitializer
    {
        public static void Initialize(SecurityDbContext context)
        {
            var users = new User[]
            {
                new User { Id = 1, Cpf = "06052555675", Email = "andre@paulovich.com", Login = "andre", Password = "parmegiana", Name = "André Paulovich" },
                new User { Id = 2, Cpf = "98735498765", Email = "ivan@paulovich.com", Login = "ivan", Password = "parmegiana", Name = "Ivan Paulovich" },
                new User { Id = 3, Cpf = "53753394122", Email = "tanato@cartaxo.com.br", Login = "tanato", Password = "bolacha", Name = "Tanato Cartaxo" },
                new User { Id = 4, Cpf = "43686265753", Email = "joao@bol.com.br", Login = "joao", Password = "biscoito", Name = "João Paulo" },
                new User { Id = 5, Cpf = "63032065810", Email = "luiz@bol.com.br", Login = "luiz", Password = "recheado", Name = "LUiz Carlos" }                
            };

            foreach (User s in users)
            {
                context.Users.Add(s);
            }

            context.SaveChanges();

            var profiles = new Profile[]
            {
                new Profile { Id = 1, Active = true, Name = "administrator" },
                new Profile { Id = 2, Active = true, Name = "manager" },
                new Profile { Id = 3, Active = true, Name = "guest" }
            };
            foreach (Profile c in profiles)
            {
                context.Profiles.Add(c);
            }

            context.SaveChanges();

            var relations = new UserProfile[]
            {
                new UserProfile { ProfileId = 1, UserId = 1 },
                new UserProfile { ProfileId = 2, UserId = 1 },
                new UserProfile { ProfileId = 3, UserId = 1 },
                new UserProfile { ProfileId = 3, UserId = 2 },
                new UserProfile { ProfileId = 3, UserId = 3 },
                new UserProfile { ProfileId = 2, UserId = 4 },
            };

            foreach (UserProfile e in relations)
            {
                context.UserProfiles.Add(e);
            }

            context.SaveChanges();

            var functions = new Functionality[]
            {
                new Functionality { Id = 1, Code = "SysAdmin", Name = "System Owner" },
                new Functionality { Id = 2, Code = "Manager", Name = "System Manager" },
                new Functionality { Id = 3, Code = "Reader", Name = "Read Information" },
                new Functionality { Id = 4, Code = "Editor", Name = "Edit Information" },
            };

            foreach (Functionality f in functions)
            {
                context.Functionalities.Add(f);
            }

            context.SaveChanges();

            var profilefunctions = new ProfileFunctionality[]
            {
                new ProfileFunctionality { FunctionalityId = 1, ProfileId = 1 },
                new ProfileFunctionality { FunctionalityId = 2, ProfileId = 1 },
                new ProfileFunctionality { FunctionalityId = 3, ProfileId = 1 },
                new ProfileFunctionality { FunctionalityId = 4, ProfileId = 1 },
                new ProfileFunctionality { FunctionalityId = 2, ProfileId = 2 },
                new ProfileFunctionality { FunctionalityId = 3, ProfileId = 2 },
                new ProfileFunctionality { FunctionalityId = 4, ProfileId = 2 },
                new ProfileFunctionality { FunctionalityId = 3, ProfileId = 3 },
            };

            foreach (ProfileFunctionality p in profilefunctions)
            {
                context.ProfileFunctionalities.Add(p);
            }

            context.SaveChanges();            
        }
    }
}
