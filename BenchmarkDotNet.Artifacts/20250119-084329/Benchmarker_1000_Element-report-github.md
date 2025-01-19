```

BenchmarkDotNet v0.14.0, Ubuntu 24.04.1 LTS (Noble Numbat) WSL
11th Gen Intel Core i5-11300H 3.10GHz, 1 CPU, 6 logical and 3 physical cores
.NET SDK 8.0.112
  [Host]     : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


```
| Method                | Mean     | Error    | StdDev   | Rank | Gen0       | Gen1       | Gen2      | Allocated |
|---------------------- |---------:|---------:|---------:|-----:|-----------:|-----------:|----------:|----------:|
| ListAndPredicate      |       NA |       NA |       NA |    ? |         NA |         NA |        NA |        NA |
| DictionaryAndContains |  6.624 s | 0.1308 s | 0.2488 s |    1 | 94000.0000 | 33000.0000 | 3000.0000 | 677.91 MB |
| HashSetAndContains    |  6.803 s | 0.1357 s | 0.3091 s |    1 | 94000.0000 | 33000.0000 | 3000.0000 | 657.35 MB |
| ListAndLINQ           | 58.131 s | 1.0155 s | 0.9002 s |    2 | 66000.0000 |          - |         - |  326.3 MB |

Benchmarks with issues:
  Benchmarker_1000_Element.ListAndPredicate: DefaultJob
