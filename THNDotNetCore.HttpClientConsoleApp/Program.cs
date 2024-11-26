// See https://aka.ms/new-console-template for more information
using THNDotNetCore.HttpClientConsoleApp;

Console.WriteLine("Hello, World!");

HttpClientExample httpClientExample = new HttpClientExample();
await httpClientExample.Read();
await httpClientExample.Edit(1);
await httpClientExample.Edit(101);