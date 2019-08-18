using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.Health.Contracts.Encryption;
using System.Security.Cryptography;

namespace DA.Health.Encryption.MD5
{
	public class Md5Hasher : IEncHasher
	{
		private MD5CryptoServiceProvider _md5CSP;
		public Md5Hasher()
		{
			_md5CSP = new MD5CryptoServiceProvider();
		}

		public string HashUserPasswort(string username, string plainPasswort)
		{
			string input = $"{username}:{plainPasswort}";
			byte[] hash = _md5CSP.ComputeHash(UnicodeEncoding.Unicode.GetBytes(input));
			return UnicodeEncoding.Unicode.GetString(hash);
		}
	}
}
