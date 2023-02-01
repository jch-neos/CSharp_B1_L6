using System;
using System.Diagnostics;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;

namespace exception {
  public class Benchmarks {
    string test = "12321a";
    [Benchmark]
    public int Try() {
      if (int.TryParse(test, out var res)) return res;
      else return int.MinValue;
    }
    [Benchmark]
    public int Parse() {
      try { return int.Parse(test); } 
      catch { return int.MinValue; }
    }
    [Benchmark]
    public int ParseMessage() {
      try { return int.Parse(test); } 
      catch(Exception e) { if(e.Message != null) {return int.MinValue;} return 0; }
    }
    [Benchmark]
    public int ParseStack() {
      try { return int.Parse(test); } 
      catch(Exception e) { if(e.StackTrace != null) {return int.MinValue;} return 0; }
    }
    [Benchmark]
    public int Parse5LevelRethrow(){
      try { return ParseRethrow(5); } 
      catch { return int.MinValue; }
    }
    public int ParseRethrow(int n){
      if(n==0) return int.Parse(test);
      try { return ParseRethrow(n-1); } 
      catch { throw; }
    }
    [Benchmark]
    public int Parse5LevelNothrow(){
      try { return ParseNoThrow(5); } 
      catch { return int.MinValue; }
    }
    public int ParseNoThrow(int n){
      if(n==0) return int.Parse(test);
      return ParseNoThrow(n-1); 
    }

    // [Benchmark]
    // public string Scenario1()
    // {
    //     try {
    //       throw new Exception();
    //     } catch(Exception e) {
    //       return e.StackTrace;
    //     }
    // }

    // [Benchmark]
    // public string Scenario2()
    // {
    //     return new StackTrace().GetFrame(1).ToString();
    // }
  }
}
