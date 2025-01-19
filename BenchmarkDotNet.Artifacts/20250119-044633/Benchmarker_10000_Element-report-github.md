```

BenchmarkDotNet v0.14.0, Ubuntu 24.04.1 LTS (Noble Numbat) WSL
11th Gen Intel Core i5-11300H 3.10GHz, 1 CPU, 6 logical and 3 physical cores
.NET SDK 8.0.112
  [Host]     : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


```
| Method                | Mean      | Error    | StdDev   | Rank | Gen0       | Gen1       | Gen2      | Allocated |
|---------------------- |----------:|---------:|---------:|-----:|-----------:|-----------:|----------:|----------:|
| ListAndPredicate      |        NA |       NA |       NA |    ? |         NA |         NA |        NA |        NA |
| DictionaryAndContains |   5.922 s | 0.0414 s | 0.0323 s |    1 | 95000.0000 | 34000.0000 | 3000.0000 | 681.18 MB |
| HashSetAndContains    |   6.050 s | 0.1200 s | 0.1122 s |    1 | 95000.0000 | 34000.0000 | 3000.0000 | 660.53 MB |
| ListAndLINQ           | 481.595 s | 0.9598 s | 0.8015 s |    2 | 67000.0000 |  1000.0000 |         - | 334.56 MB |

Benchmarks with issues:
  Benchmarker_10000_Element.ListAndPredicate: DefaultJob
