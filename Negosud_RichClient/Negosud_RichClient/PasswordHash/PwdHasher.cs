//using Microsoft.Extensions.Options;
//using System;
//using System.Linq;
//using System.Security.Cryptography;
//using Negosud_RichClient.Migrations;

//namespace Negosud_RichClient.PasswordHash
//{

//    // IPwdHasher interface implementation, but no class can inherit from PwdHasher
//    public sealed class PwdHasher : IPwdHasher
//        { 
//        // Salt size definition, in order to match with 128 bits variable
//        private const int SaltSize = 16;
//        // Password size definition, in order to match with 512 bits variable
//        private const int PassSize = 64;

//        // Declare _context as a NegosudDbContext type
//        // (private read-only member variable of type NegosudDbContext)
//        private readonly NegosudDbContext _context;  

//        // Declare Option as a HashOption type      
//        private HashOption Options { get; }

//        // Call HashOption and NegosudDbContext as PwdHasher ctor parameters
//        // and initialize them in ctor
//        public PwdHasher(
//            IOptions<HashOption> options,
//            NegosudDbContext context)
//        {
//            Options = options.Value;
//            _context = context;
//        }



//        // Hash method using Rfc2898DeriveBytes algorithm with salt
//        public byte[] Hash(string password)
//        {
//            byte[] salt = new byte[SaltSize];
//            var rng = RandomNumberGenerator.Create();
//            rng.GetNonZeroBytes(salt);

//            Rfc2898DeriveBytes algorithm = new(
//              password,
//              salt,
//              Options.Iterations,
//              HashAlgorithmName.SHA512);

//            byte[] hashpass = algorithm.GetBytes(PassSize);

//            byte[] hashBytes = new byte[PassSize + SaltSize];
//            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
//            Array.Copy(hashpass, 0, hashBytes, SaltSize, PassSize);

//            return hashBytes;
//        }



//        // Verify compatibility between stored and submitted password
//        public bool Check(string username, string password)
//        {

//            var user = _context.Users.Where(b => b.Username == username).FirstOrDefault();

//            byte[] stockedKey = user.HashPassword;

//            byte[] stockedSalt = new byte[SaltSize];
//            Array.Copy(stockedKey, 0, stockedSalt, 0, SaltSize);

//            Rfc2898DeriveBytes algorithm = new(
//              password,
//              stockedSalt,
//              Options.Iterations,              
//              HashAlgorithmName.SHA512);

//            byte[] hashedPass = algorithm.GetBytes(PassSize);

//            byte[] keyToCheck = new byte[SaltSize + PassSize];
//            Array.Copy(stockedSalt, 0, keyToCheck, 0, SaltSize);
//            Array.Copy(hashedPass, 0, keyToCheck, SaltSize, PassSize);


//            if (stockedKey.SequenceEqual(keyToCheck))
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }

//        }
//    }
//}