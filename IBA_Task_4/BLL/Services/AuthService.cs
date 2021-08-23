namespace BLL.Services
{
    public static class AuthService
    {
        private const string _salt = "$2a$11$iOlBDNEkOb9n3D9F1PO3N.";

        /// <summary>
        /// Get a hash.
        /// </summary>
        /// <param name="password">Password.</param>
        /// <returns>Hash</returns>
        /// <exception cref="System.ArgumentNullException">If the password is null or empty</exception>
        public static string GetHash(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new System.ArgumentNullException(nameof(password));

            password = password.Trim().ToLower();

            return BCrypt.Net.BCrypt.HashPassword(password, _salt, false, BCrypt.Net.HashType.SHA512);
        }
    }
}
