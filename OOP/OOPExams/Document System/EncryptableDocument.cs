using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class EncryptableDocument : BinaryDocument, IEncryptable
{
    public bool IsEncrypted { get; private set; }

    public void Encrypt()
    {
        this.IsEncrypted = true;
    }

    public void Decrypt()
    {
        this.IsEncrypted = false;
    }
}

