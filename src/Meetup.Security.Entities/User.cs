using System.Collections.Generic;

namespace Meetup.Security.Entities
{
    public class User
    {
        public User()
        {
            UserProfiles = new List<UserProfile>();
        }

        #region Properties

        public long Id { get; set; }

        /// <summary>
        /// Nome do usuário
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Email do usuário
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Login do usuário
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// CPF do usuário
        /// </summary>
        public string Cpf { get; set; }

        /// <summary>
        /// Senha do usuário
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Perfis do usuário
        /// </summary>
        public virtual ICollection<UserProfile> UserProfiles { get; set; }

        #endregion
    }
}
