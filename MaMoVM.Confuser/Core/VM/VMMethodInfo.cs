﻿#region

using System.Collections.Generic;
using MaMoVM.Confuser.Core.CFG;

#endregion

namespace MaMoVM.Confuser.Core.VM
{
    public class VMMethodInfo
    {
        public readonly Dictionary<IBasicBlock, VMBlockKey> BlockKeys;
        public readonly HashSet<VMRegisters> UsedRegister;
        public byte EntryKey;
        public byte ExitKey;

        public ScopeBlock RootScope;

        public VMMethodInfo()
        {
            BlockKeys = new Dictionary<IBasicBlock, VMBlockKey>();
            UsedRegister = new HashSet<VMRegisters>();
        }
    }

    public struct VMBlockKey
    {
        public byte EntryKey;
        public byte ExitKey;
    }
}