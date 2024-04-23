﻿using MaMoVM.Runtime.Dynamic;
using MaMoVM.Runtime.Execution;

namespace MaMoVM.Runtime.VCalls
{
    internal class Throw : IVCall
    {
        public byte Code => Constants.VCALL_THROW;

        [VMProtect.BeginMutation]
        public void Run(VMContext ctx, out ExecutionState state)
        {
            var sp = ctx.Registers[Constants.REG_SP].U4;
            var type = ctx.Stack[sp--].U4;
            ctx.Registers[Constants.REG_SP].U4 = sp;
            if(type == 1)
                state = ExecutionState.Rethrow;
            else
                state = ExecutionState.Throw;
        }
    }
}