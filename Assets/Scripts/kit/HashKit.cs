using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class HashKit {

    public static byte[] ShaBytes(string data, string algorithm) {
        var hash = HashAlgorithm.Create(algorithm);
        var bytes = Encoding.UTF8.GetBytes(data);
        return hash.ComputeHash(bytes);
    }

    public static string ShaString(string data, string algorithm) {
        var result = ShaBytes(data, algorithm);
        return BitConverter.ToString(result);
    }
}
