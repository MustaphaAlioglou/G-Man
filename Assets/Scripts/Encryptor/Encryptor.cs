using System;
using System.IO;
using System.Security.Cryptography;

public class Encryptor
{
    private byte[] _key = { 0x05, 0x14, 0x14, 0x45, 0x55, 0x47, 0x17, 0x68, 0x14, 0x58, 0x58, 0x21, 0x22, 0x22, 0x22, 0x63 };
    private byte[] _iv = { 0x05, 0x14, 0x14, 0x45, 0x55, 0x47, 0x17, 0x68, 0x14, 0x58, 0x58, 0x21, 0x22, 0x22, 0x22, 0x63 };

    public byte[] Encrypt(string plainText)
    {
        AesManaged aes = new AesManaged();
        ICryptoTransform encryptor = aes.CreateEncryptor(_key, _iv);
        using (MemoryStream MEMSTREAM = new MemoryStream())
        {
            using (CryptoStream CRYPTOSTREAM = new CryptoStream(MEMSTREAM, encryptor, CryptoStreamMode.Write))
            {
                using (StreamWriter streamWriter = new StreamWriter(CRYPTOSTREAM))
                {
                    streamWriter.Write(plainText);
                }
            }
            return MEMSTREAM.ToArray();
        }
    }

    public string Decrypt(byte[] Encrypted)
    {
        string DecryptedMessage = string.Empty;
        AesManaged aes = new AesManaged();
        ICryptoTransform encryptor = aes.CreateDecryptor(_key, _iv);

        using (MemoryStream MEMSTREAM = new MemoryStream(Encrypted))
        {
            using (CryptoStream CRYPTOSTREAM = new CryptoStream(MEMSTREAM, encryptor, CryptoStreamMode.Read))
            {
                using (StreamReader streamReader = new StreamReader(CRYPTOSTREAM))
                {
                    DecryptedMessage = streamReader.ReadToEnd();
                }
            }
            return DecryptedMessage;
        }
    }
}