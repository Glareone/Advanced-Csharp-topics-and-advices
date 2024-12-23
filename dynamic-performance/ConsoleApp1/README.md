# Dynamic <-> Reflection <-> Generic Benchmarking

You may find code here: https://github.com/Glareone/Advanced-Csharp-topics/tree/main/dynamic-performance/ConsoleApp1

## Dynamic usecases

* How to use dynamic to call Python code and to build ExpandoObject (dynamic object with dynamic properties);
* You may find examples with Python Code in PythonAsText project

## These examples will let you know whether Dynamic is really slow and if it's true - how much comparing with Reflection and direct allocation or method's call.
* You may find examples in Dynamic.Performance project

Benchmark results:  
* Methods called directly, using reflection, using dynamic and using dynamic ExpandoObject  
![image](https://github.com/Glareone/Advanced-Csharp-topics/assets/4239376/97ba19bc-66da-486b-8d23-2c0456ebb815)  
Usually reflection is a bit faster than dynamic method. And it's a bit slower if you pass both parameters to method. Very interesting.  
![image](https://github.com/Glareone/Advanced-Csharp-topics/assets/4239376/a01e651d-deab-4637-8481-535d76ffddff)

* Allocation using Generic vs Dynamic  
![image](https://github.com/Glareone/Advanced-Csharp-topics/assets/4239376/ebd52c95-87bd-40d5-a2f6-a6986306970a)
