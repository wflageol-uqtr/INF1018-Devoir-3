namespace INF1018_Devoir_3_Tests

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open INF1018_Devoir_3.Interpreter

[<TestClass>]
type TestClass () =

    [<TestMethod>]
    member this.TestScalar1 () =
        let result = interpret [Int 42] 0 0 0
        Assert.AreEqual (42, result)

    [<TestMethod>]
    member this.TestScalar2 () =
        let result = interpret [Var C] 0 0 -64
        Assert.AreEqual (-64, result)

    [<TestMethod>]
    member this.TestSimpleEquation1 () =
        let result = interpret [Int 18; Op Plus; Var B] 0 12 0
        Assert.AreEqual (30, result)

    [<TestMethod>]
    member this.TestSimpleEquation2 () =
        let result = interpret [Var A; Op Divide; Var B] 64 12 0
        Assert.AreEqual (5, result)

    [<TestMethod>]
    member this.TestLongEquation () =
        let result = interpret [Var A; Op Multiply; Var B; Op Minus; Var C; Op Plus; Int 12] 
                               2 3 2
        Assert.AreEqual (16, result)


