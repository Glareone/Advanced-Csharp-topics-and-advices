# Advanced C# topics and pieces of advice.
## Practical Part
In this repository I will try to explain good concepts regarding Async, regarding Logging and so on.

# Topics
&#9745; Async  
&#9745; IAsyncEnumerable. [Async Streams and when to use async before foreach](https://learn.microsoft.com/en-us/answers/questions/1046784/c-async-streams-when-to-use-await-before-foreach)  
  - Async materials are here: [Async materials](https://github.com/Glareone/C-Advices/tree/main/Async/Async_Mistakes)  
  - Async void pitfalls (in progress)

&#9745; Logging in minimalAPI: 
  - [Logging using JsonFormat and W3C](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter05-Logging)  
  - [Logging using Serilog and AppInsights](https://github.com/Glareone/Minimal-API-.Net6/tree/main/Chapters/MinimalAPI/Chapter05-Logging-Serilog)

&#9745; Nullable Reference Types   
  - [Nullable Reference Types. Article in a Blog](https://thecodeblogger.com/2022/05/26/getting-started-on-nullable-reference-types/)  

&#9744; Prevent from decompiling your C#-application  
&#9744; Validation. Settings Validation   
  - [Fluent Validation in MinimalAPI](https://github.com/Glareone/Minimal-API-.Net6/tree/main/Chapters/MinimalAPI/Chapter06-Model-FluentValidation)  
  - IValidation (in progress)  

## Azure Cloud
&#9745; [Azure Function .Net8 with Serilog, Production Ready](https://github.com/Glareone/Advanced-Csharp-topics/tree/main/AzureFunctions/AzureFunction.Examples) 

## Authentication & Authorization

&#9745; [Authentication using JWT](https://github.com/Glareone/Minimal-API-.Net6/tree/main/Chapters/MinimalAPI/Chapter09-Authentication)  
&#9745; Authorization  
  - [Role-based](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter09-Authentication-AuthorizationClaims/MapHelper/RoleBasedAdminEndpointHelper.cs)  
  - [Policy-based](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter09-Authentication-AuthorizationClaims/MapHelper/PolicyBasedEndpointHelper.cs)  
  - [Policy-Requirement. Custom Policy](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter09-Authentication-AuthorizationClaims/MapHelper/PolicyRequirementProtectedEndpointHelper.cs)  
  - [Fallback & Default Policies](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter09-Authentication-AuthorizationClaims/Program.cs#L66)  
  - [Anonymous](https://github.com/Glareone/Minimal-API-.Net6/blob/main/Chapters/MinimalAPI/Chapter09-Authentication-AuthorizationClaims/MapHelper/AnonymousEndpoints.cs)   

## Other materials

&#9745; [.editorconfig](https://github.com/Glareone/Advanced-Csharp-topics/tree/main/editorconfig/BlazorAppWithEditorConfig)
  - Good Explanation: [EditorConfig in VisualStudio in 10 minutes](https://www.youtube.com/watch?v=CQW5b58mPdg)

&#9745; Worker (CPU-bound) & Completion (I\O-bound) Threads  [Worker & CompletionThreads.pptx](https://github.com/Glareone/Advanced-C-topics-and-advices/files/8886222/Worker.CompletionThreads.pptx)  
&#9744; GC, IDisposable, and Finalizer (in progress) GC and related materials are here: 
  - [GC Materials](https://github.com/Glareone/C-Advices/tree/main/GC,%20IDisposable,%20Finalizer)  
  - [Resurrection in .Net, GC Generations](https://medium.com/@vasylsenko/resurrection-in-net-framework-e6c8108e2122)
  - [GC internals by Konrad Kokosa on Youtube](https://www.youtube.com/watch?v=8i1Nv7wGsjk&list=PLpUkQYy-K8Y-wYcDgDXKhfs6OT8fFQtVm)
  - .Netos slides\goodies: [https://goodies.dotnetos.org](https://goodies.dotnetos.org/)  

&#9745; [ReadOnlySpan](https://github.com/Glareone/C-Advices/tree/main/ReadOnlySpan), **ref struct** and how to not allocate extra memory in heap   
&#9745; [PeriodicTimer, modern way how to run background tasks](https://github.com/Glareone/C-Advices/tree/main/PeriodicTimer/PeriodicTimer)  

## Delegates and usecases

&#9744; Delegates. Delegates use cases in C#10  

## Benchmarking the different usecases

&#9745; Benchmarks  
  - [Benchmark: Loops with Linq, Parallel, and Span](https://github.com/Glareone/C-Advices/tree/main/Benchmarking/Looping-Foreach-Others/BenchmarkForDifferentLoops/BenchmarkForDifferentLoops)  
  - [Benchmark memory: ReadOnlySpan](https://github.com/Glareone/C-Advices/tree/main/ReadOnlySpan/Repo)  
  - [Benchmark results: MinimalAPI vs ControllerAPI](https://github.com/Glareone/Minimal-API-.Net6/blob/main/README.md#compare-controllers-vs-minimalapi)  
  - [Benchmarking Minimal API using K6](https://github.com/Glareone/Minimal-API-.Net6/tree/main/Chapters/MinimalAPI/Chapter11-Performance-Benchmark-K6-BenchmarkDotNet)  
  - [Benchmarking Controller APi using K6](https://github.com/Glareone/Minimal-API-.Net6/tree/main/Chapters/MinimalAPI/Chapter11-2-Controllers-K6-BenchmarkDotNet)  
  - [Benchmarking API using BenchmarkDotNet. Benchmark Runner](https://github.com/Glareone/Minimal-API-.Net6/tree/main/Chapters/MinimalAPI/Chapter11-BenchmarkDotNet-Runner-forAPI)  
  
&#9744;  Benchmarking WebAPI and GC utilization in it. CQRS Cost. 
  - [Little CQRS + .Net5 project example](https://github.com/Glareone/CQRS-with-MediatR-.Net5)
  - Cost of CQRS. SPOILER: Around 5-8% depends on amount of memory allocated for your container with running application.

&#9744; HybridCache in .Net8 (in progress)

## Theory and practice

&#9744; Data Structures
  - [MIT 6.851. "Advanced Data Structures" Course](https://www.youtube.com/watch?v=T0yzrZL1py0&list=PLUl4u3cNGP61hsJNdULdudlRL493b-XZf)

&#9744; Reflection and its performance in modern C#. Dynamic as "Instead of Reflection"
  - Dynamic in modern C# (in progress)
  - Reflections and its performance in NET8 Preview (in progress)
 
&#9745; Console App with Generic Host. Running application from the pipeline. (useful for DB Migration)

&#9745; Error Handling. RFC 9547 and RFC 7807, following IETF Standards
  - [RFC 9547 Error handling using ProblemDetails](https://github.com/Glareone/Minimal-API-Controllerless-Fluent-Net8/tree/main/Chapters/MinimalAPI/Chapter12-API-Error-Format%20RFC%209457)
  - [RFC 7807 Error handling using general approach](https://github.com/Glareone/Minimal-API-Controllerless-Fluent-Net8/tree/main/Chapters/MinimalAPI/Chapter04-ExceptionHandling)  

**Allows to run any Tasks and use Host services lifetime. Might be useful to run EF DBMigrations from Pipeline or from another place**
https://dfederm.com/building-a-console-app-with-.net-generic-host/

&#9744; EntityFramework vs Dapper. Improving speed of EntityFramework  (in progress)  
&#9744; Kafka meets .Net6  (in progress)  
&#9745; [GraphQL meets .Net6](https://github.com/Glareone/GraphQL-meets-.Net6)   
&#9745; Bloom Filter (in progress. Could be found below)

<details>
<summary>Bloom Filter. Pros and Cons. Types. Use Cases</summary>
  
## Use Cases
![image](https://github.com/Glareone/Advanced-Csharp-topics/assets/4239376/a797c7cd-7c1b-424f-962a-3f679b2a5901)

## Pros
![image](https://github.com/Glareone/Advanced-Csharp-topics/assets/4239376/96e86891-641a-43ec-b004-eaf936373d0c)
 
## Cons
![image](https://github.com/Glareone/Advanced-Csharp-topics/assets/4239376/88d10779-5ba2-4ce7-a88a-1f1e8f807f51)
</details>

&#9745; [Dynamic. Performance. Comparison](https://github.com/Glareone/Advanced-Csharp-topics/blob/main/dynamic-performance/ConsoleApp1/README.md)  

&#9744; Retries in .Net  
&#9744; String.Create (example from Dave is in the section below) 
<details>
<summary>String.Create example (let us not allocating extra space when we tend to construct the string). Faster than String.Join and String Interpolation</summary>

![image](https://github.com/Glareone/Grokking-Algorithms-LeetCode-DesignGurus/assets/4239376/2dc93afb-7605-4c19-a6a0-d654e025cea1)
</details>
