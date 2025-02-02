﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Security
{
    /// <summary>
    /// ALEXFW cookies token.
    /// </summary>
    [Serializable]
    public sealed class ALEXFWCookiesToken : ALEXFWToken
    {
        /// <summary>
        /// Get or set the username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Get or set the expired date.
        /// </summary>
        public DateTime ExpiredDate { get; set; }

        /// <summary>
        /// Get token byte data without signature.
        /// </summary>
        /// <returns></returns>
        public override byte[] GetTokenData()
        {
            return Encoding.UTF8.GetBytes(Username).Concat(BitConverter.GetBytes(ExpiredDate.ToBinary())).ToArray();
        }
    }
}
