// Decompiled with JetBrains decompiler
// Type: ConsoleApp8.Program
// Assembly: ConsoleApp8, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3FC7F022-1ACE-42A5-A02E-827FD183D050
// Assembly location: C:\Users\ASUS\source\repos\ConsoleApp8\bin\Debug\net8.0\ConsoleApp8.dll
// Local variable names from C:\Users\ASUS\source\repos\ConsoleApp8\bin\Debug\net8.0\ConsoleApp8.pdb
// Compiler-generated code is shown

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ConsoleApp8;

public class Transaction
{
    public async Task<int> CalculateTransaction(int amount)
    {
        await Task.Delay(1000);
        return amount / 100;
    }
}
internal class Program
{


    [AsyncStateMachine(typeof(CalculatorStateMachine))]
    [DebuggerStepThrough]
    private static Task Main(string[] args)
    {
        CalculatorStateMachine stateMachine = new CalculatorStateMachine();
        stateMachine.asyncMethodBuilder = AsyncTaskMethodBuilder.Create();
        stateMachine.currentState = -1;
        stateMachine.asyncMethodBuilder.Start(ref stateMachine);
        return stateMachine.asyncMethodBuilder.Task;
    }


}

[CompilerGenerated]
public sealed class CalculatorStateMachine : IAsyncStateMachine
{
    public int currentState;
    public AsyncTaskMethodBuilder asyncMethodBuilder;
    private int currentResponse;
    private int tempResponse;
    private TaskAwaiter<int> awaiter;

    void IAsyncStateMachine.MoveNext()
    {
        int num1 = this.currentState;
        try
        {
            DefaultInterpolatedStringHandler interpolatedStringHandler;
            TaskAwaiter<int> awaiter;
            int num2;
            if (num1 != 0)
            {
                interpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 1);
                interpolatedStringHandler.AppendLiteral("Operation started in thread = ");
                interpolatedStringHandler.AppendFormatted<int>(Environment.CurrentManagedThreadId);
                Console.WriteLine(interpolatedStringHandler.ToStringAndClear());
                awaiter = new Transaction().CalculateTransaction(300000).GetAwaiter();
                if (!awaiter.IsCompleted)
                {
                    this.currentState = num2 = 0;
                    this.awaiter = awaiter;
                    CalculatorStateMachine stateMachine = this;
                    this.asyncMethodBuilder.AwaitUnsafeOnCompleted<TaskAwaiter<int>, CalculatorStateMachine>(ref awaiter, ref stateMachine);
                    return;
                }
            }
            else
            {
                awaiter = this.awaiter;
                this.awaiter = new TaskAwaiter<int>();
                this.currentState = num2 = -1;
            }
            this.tempResponse = awaiter.GetResult();
            this.currentResponse = this.tempResponse;
            interpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 1);
            interpolatedStringHandler.AppendLiteral("Operation continues in thread = ");
            interpolatedStringHandler.AppendFormatted<int>(Environment.CurrentManagedThreadId);
            Console.WriteLine(interpolatedStringHandler.ToStringAndClear());
        }
        catch (Exception ex)
        {
            this.currentState = -2;
            this.asyncMethodBuilder.SetException(ex);
            return;
        }
        this.currentState = -2;
        this.asyncMethodBuilder.SetResult();
    }

    [DebuggerHidden]
    void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
    {
    }
}
