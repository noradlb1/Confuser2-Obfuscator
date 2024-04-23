﻿using System;
using System.Collections.Generic;
using MaMoVM.Runtime.VCalls;

namespace MaMoVM.Runtime.Data
{
    internal static class VCallMap
    {
        private static readonly Dictionary<byte, IVCall> vCalls;

        [VMProtect.BeginUltra]
        static VCallMap()
        {
            vCalls = new Dictionary<byte, IVCall>();
            foreach(var type in typeof(VCallMap).Assembly.GetTypes())
                if(typeof(IVCall).IsAssignableFrom(type) && !type.IsAbstract)
                {
                    var vCall = (IVCall) Activator.CreateInstance(type);
                    vCalls[vCall.Code] = vCall;
                }
        }

        [VMProtect.BeginMutation]
        public static IVCall Lookup(byte code)
        {
            return vCalls[code];
        }
    }
}