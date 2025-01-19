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
| DictionaryAndContains |   5.693 s | 0.0981 s | 0.0917 s |    1 | 93000.0000 | 32000.0000 | 1000.0000 | 680.75 MB |
| HashSetAndContains    |   5.865 s | 0.1118 s | 0.2334 s |    1 | 94000.0000 | 33000.0000 | 3000.0000 | 660.41 MB |
| ListAndLINQ           | 476.148 s | 4.4291 s | 3.6985 s |    2 | 68000.0000 |  1000.0000 |         - | 334.38 MB |

Benchmarks with issues:
  Benchmarker_10000_Element.ListAndPredicate: DefaultJob
