<a name='assembly'></a>
# Study.LabWork2

## Contents

- [AsynchronousServerRequestApp](#T-Study-LabWork2-Feature-Task2-AsynchronousServerRequestApp 'Study.LabWork2.Feature.Task2.AsynchronousServerRequestApp')
  - [ExecuteRequestsAsync\`\`1()](#M-Study-LabWork2-Feature-Task2-AsynchronousServerRequestApp-ExecuteRequestsAsync``1-Study-LabWork2-Abstractions-Feature-Task2-DtoModels-ServerConfigDto[]- 'Study.LabWork2.Feature.Task2.AsynchronousServerRequestApp.ExecuteRequestsAsync``1(Study.LabWork2.Abstractions.Feature.Task2.DtoModels.ServerConfigDto[])')
- [DataSets](#T-Study-LabWork2-Feature-Task1-SubTask2-DataSets 'Study.LabWork2.Feature.Task1.SubTask2.DataSets')
  - [Sets](#P-Study-LabWork2-Feature-Task1-SubTask2-DataSets-Sets 'Study.LabWork2.Feature.Task1.SubTask2.DataSets.Sets')
  - [GenerateAndSave()](#M-Study-LabWork2-Feature-Task1-SubTask2-DataSets-GenerateAndSave 'Study.LabWork2.Feature.Task1.SubTask2.DataSets.GenerateAndSave')
  - [Load()](#M-Study-LabWork2-Feature-Task1-SubTask2-DataSets-Load 'Study.LabWork2.Feature.Task1.SubTask2.DataSets.Load')
- [MonitorService](#T-Study-LabWork2-Feature-Task1-SubTask1-MonitorService 'Study.LabWork2.Feature.Task1.SubTask1.MonitorService')
  - [CountPrimes(start,end,threadCount)](#M-Study-LabWork2-Feature-Task1-SubTask1-MonitorService-CountPrimes-System-Int32,System-Int32,System-Int32- 'Study.LabWork2.Feature.Task1.SubTask1.MonitorService.CountPrimes(System.Int32,System.Int32,System.Int32)')
  - [GetVersionName()](#M-Study-LabWork2-Feature-Task1-SubTask1-MonitorService-GetVersionName 'Study.LabWork2.Feature.Task1.SubTask1.MonitorService.GetVersionName')
  - [ProcessRange()](#M-Study-LabWork2-Feature-Task1-SubTask1-MonitorService-ProcessRange-System-Int32,System-Int32,System-Int32,System-Object,System-Int32@,System-Collections-Generic-List{System-Int32},System-Boolean- 'Study.LabWork2.Feature.Task1.SubTask1.MonitorService.ProcessRange(System.Int32,System.Int32,System.Int32,System.Object,System.Int32@,System.Collections.Generic.List{System.Int32},System.Boolean)')
- [MutexService](#T-Study-LabWork2-Feature-Task1-SubTask1-MutexService 'Study.LabWork2.Feature.Task1.SubTask1.MutexService')
  - [CountPrimes()](#M-Study-LabWork2-Feature-Task1-SubTask1-MutexService-CountPrimes-System-Int32,System-Int32,System-Int32- 'Study.LabWork2.Feature.Task1.SubTask1.MutexService.CountPrimes(System.Int32,System.Int32,System.Int32)')
  - [GetVersionName()](#M-Study-LabWork2-Feature-Task1-SubTask1-MutexService-GetVersionName 'Study.LabWork2.Feature.Task1.SubTask1.MutexService.GetVersionName')
- [NumberSetProcessor](#T-Study-LabWork2-Feature-Task1-SubTask2-NumberSetProcessor 'Study.LabWork2.Feature.Task1.SubTask2.NumberSetProcessor')
  - [#ctor(dataSets,maxConcurrentThreads)](#M-Study-LabWork2-Feature-Task1-SubTask2-NumberSetProcessor-#ctor-System-Collections-Generic-List{System-Int32[]},System-Int32- 'Study.LabWork2.Feature.Task1.SubTask2.NumberSetProcessor.#ctor(System.Collections.Generic.List{System.Int32[]},System.Int32)')
  - [GetResult()](#M-Study-LabWork2-Feature-Task1-SubTask2-NumberSetProcessor-GetResult 'Study.LabWork2.Feature.Task1.SubTask2.NumberSetProcessor.GetResult')
  - [Process()](#M-Study-LabWork2-Feature-Task1-SubTask2-NumberSetProcessor-Process 'Study.LabWork2.Feature.Task1.SubTask2.NumberSetProcessor.Process')
  - [ProcessSet(setNumber,numbers)](#M-Study-LabWork2-Feature-Task1-SubTask2-NumberSetProcessor-ProcessSet-System-Int32,System-Int32[]- 'Study.LabWork2.Feature.Task1.SubTask2.NumberSetProcessor.ProcessSet(System.Int32,System.Int32[])')
- [PrimeChecker](#T-Study-LabWork2-Feature-Task1-SubTask1-PrimeChecker 'Study.LabWork2.Feature.Task1.SubTask1.PrimeChecker')
  - [IsPrime(number)](#M-Study-LabWork2-Feature-Task1-SubTask1-PrimeChecker-IsPrime-System-Int32- 'Study.LabWork2.Feature.Task1.SubTask1.PrimeChecker.IsPrime(System.Int32)')
- [Program](#T-Study-LabWork2-Program 'Study.LabWork2.Program')
  - [Main()](#M-Study-LabWork2-Program-Main 'Study.LabWork2.Program.Main')
- [SemaphoreService](#T-Study-LabWork2-Feature-Task1-SubTask1-SemaphoreService 'Study.LabWork2.Feature.Task1.SubTask1.SemaphoreService')
  - [CountPrimes()](#M-Study-LabWork2-Feature-Task1-SubTask1-SemaphoreService-CountPrimes-System-Int32,System-Int32,System-Int32- 'Study.LabWork2.Feature.Task1.SubTask1.SemaphoreService.CountPrimes(System.Int32,System.Int32,System.Int32)')
  - [GetVersionName()](#M-Study-LabWork2-Feature-Task1-SubTask1-SemaphoreService-GetVersionName 'Study.LabWork2.Feature.Task1.SubTask1.SemaphoreService.GetVersionName')
- [SynchronousServerRequestApp](#T-Study-LabWork2-Feature-Task2-SynchronousServerRequestApp 'Study.LabWork2.Feature.Task2.SynchronousServerRequestApp')
- [TaskRun1_1](#T-Study-LabWork2-Feature-Task1-SubTask1-TaskRun1_1 'Study.LabWork2.Feature.Task1.SubTask1.TaskRun1_1')
  - [Run()](#M-Study-LabWork2-Feature-Task1-SubTask1-TaskRun1_1-Run 'Study.LabWork2.Feature.Task1.SubTask1.TaskRun1_1.Run')
  - [RunService()](#M-Study-LabWork2-Feature-Task1-SubTask1-TaskRun1_1-RunService-Study-LabWork2-Abstractions-Feature-Task1-SubTask1-IPrimeCounter,System-Int32,System-Int32,System-Int32- 'Study.LabWork2.Feature.Task1.SubTask1.TaskRun1_1.RunService(Study.LabWork2.Abstractions.Feature.Task1.SubTask1.IPrimeCounter,System.Int32,System.Int32,System.Int32)')
- [TaskRun1_2](#T-Study-LabWork2-Feature-Task1-SubTask2-TaskRun1_2 'Study.LabWork2.Feature.Task1.SubTask2.TaskRun1_2')
  - [Run()](#M-Study-LabWork2-Feature-Task1-SubTask2-TaskRun1_2-Run 'Study.LabWork2.Feature.Task1.SubTask2.TaskRun1_2.Run')

<a name='T-Study-LabWork2-Feature-Task2-AsynchronousServerRequestApp'></a>
## AsynchronousServerRequestApp `type`

##### Namespace

Study.LabWork2.Feature.Task2

##### Summary

Асинхронная версия приложения (с использованием async/await)

<a name='M-Study-LabWork2-Feature-Task2-AsynchronousServerRequestApp-ExecuteRequestsAsync``1-Study-LabWork2-Abstractions-Feature-Task2-DtoModels-ServerConfigDto[]-'></a>
### ExecuteRequestsAsync\`\`1() `method`

##### Summary

Асинхронное выполнение запросов

##### Parameters

This method has no parameters.

<a name='T-Study-LabWork2-Feature-Task1-SubTask2-DataSets'></a>
## DataSets `type`

##### Namespace

Study.LabWork2.Feature.Task1.SubTask2

##### Summary

Хранит 15 наборов по 100 случайных чисел от 1 до 100.

<a name='P-Study-LabWork2-Feature-Task1-SubTask2-DataSets-Sets'></a>
### Sets `property`

##### Summary

Список наборов чисел. Каждый набор — массив из 100 чисел.

<a name='M-Study-LabWork2-Feature-Task1-SubTask2-DataSets-GenerateAndSave'></a>
### GenerateAndSave() `method`

##### Summary

Генерирует 15 наборов чисел с фиксированным seed и сохраняет в JSON-файл.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-Feature-Task1-SubTask2-DataSets-Load'></a>
### Load() `method`

##### Summary

Загружает наборы данных из JSON-файла.

##### Returns

Объект DataSets с наборами чисел.

##### Parameters

This method has no parameters.

<a name='T-Study-LabWork2-Feature-Task1-SubTask1-MonitorService'></a>
## MonitorService `type`

##### Namespace

Study.LabWork2.Feature.Task1.SubTask1

##### Summary

Версия 1. Использует Monitor (lock) для синхронизации.

<a name='M-Study-LabWork2-Feature-Task1-SubTask1-MonitorService-CountPrimes-System-Int32,System-Int32,System-Int32-'></a>
### CountPrimes(start,end,threadCount) `method`

##### Summary

Запускает подсчет простых чисел в заданном диапазоне.

##### Returns

Результат подсчета.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| start | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Начало диапазона (включительно). |
| end | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Конец диапазона (включительно). |
| threadCount | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Количество потоков для подсчета. |

<a name='M-Study-LabWork2-Feature-Task1-SubTask1-MonitorService-GetVersionName'></a>
### GetVersionName() `method`

##### Summary

Возвращает название версии счетчика.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-Feature-Task1-SubTask1-MonitorService-ProcessRange-System-Int32,System-Int32,System-Int32,System-Object,System-Int32@,System-Collections-Generic-List{System-Int32},System-Boolean-'></a>
### ProcessRange() `method`

##### Summary

Обрабатывает заданный диапазон чисел в отдельном потоке.

##### Parameters

This method has no parameters.

<a name='T-Study-LabWork2-Feature-Task1-SubTask1-MutexService'></a>
## MutexService `type`

##### Namespace

Study.LabWork2.Feature.Task1.SubTask1

##### Summary

Версия 2. Использует Mutex для синхронизации.

<a name='M-Study-LabWork2-Feature-Task1-SubTask1-MutexService-CountPrimes-System-Int32,System-Int32,System-Int32-'></a>
### CountPrimes() `method`

##### Summary

Запускает подсчет простых чисел в заданном диапазоне.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-Feature-Task1-SubTask1-MutexService-GetVersionName'></a>
### GetVersionName() `method`

##### Summary

Возвращает название версии счетчика.

##### Parameters

This method has no parameters.

<a name='T-Study-LabWork2-Feature-Task1-SubTask2-NumberSetProcessor'></a>
## NumberSetProcessor `type`

##### Namespace

Study.LabWork2.Feature.Task1.SubTask2

##### Summary

Определяет реализацию для процессора наборов чисел

<a name='M-Study-LabWork2-Feature-Task1-SubTask2-NumberSetProcessor-#ctor-System-Collections-Generic-List{System-Int32[]},System-Int32-'></a>
### #ctor(dataSets,maxConcurrentThreads) `constructor`

##### Summary

Конструктор.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dataSets | [System.Collections.Generic.List{System.Int32[]}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{System.Int32[]}') | Список наборов чисел для обработки. |
| maxConcurrentThreads | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Максимальное количество одновременно работающих потоков. |

<a name='M-Study-LabWork2-Feature-Task1-SubTask2-NumberSetProcessor-GetResult'></a>
### GetResult() `method`

##### Summary

Возвращает результат обработки.

##### Returns

DTO с результатами обработки всех наборов.

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | Если обработка ещё не запущена. |

<a name='M-Study-LabWork2-Feature-Task1-SubTask2-NumberSetProcessor-Process'></a>
### Process() `method`

##### Summary

Запускает процесс многопоточной обработки наборов чисел.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-Feature-Task1-SubTask2-NumberSetProcessor-ProcessSet-System-Int32,System-Int32[]-'></a>
### ProcessSet(setNumber,numbers) `method`

##### Summary

Обрабатывает один набор чисел в отдельном потоке.
Вычисляет сумму и сохраняет результат.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| setNumber | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Номер набора (для вывода). |
| numbers | [System.Int32[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32[] 'System.Int32[]') | Массив чисел для суммирования. |

<a name='T-Study-LabWork2-Feature-Task1-SubTask1-PrimeChecker'></a>
## PrimeChecker `type`

##### Namespace

Study.LabWork2.Feature.Task1.SubTask1

<a name='M-Study-LabWork2-Feature-Task1-SubTask1-PrimeChecker-IsPrime-System-Int32-'></a>
### IsPrime(number) `method`

##### Summary

Проверяет, является ли число простым.

##### Returns

true, если число простое; иначе false.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| number | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Проверяемое число. |

<a name='T-Study-LabWork2-Program'></a>
## Program `type`

##### Namespace

Study.LabWork2

##### Summary

Запускает все три версии подсчёта простых чисел.

<a name='M-Study-LabWork2-Program-Main'></a>
### Main() `method`

##### Summary

Точка входа в программу.

##### Parameters

This method has no parameters.

<a name='T-Study-LabWork2-Feature-Task1-SubTask1-SemaphoreService'></a>
## SemaphoreService `type`

##### Namespace

Study.LabWork2.Feature.Task1.SubTask1

##### Summary

Версия 3. Использует Semaphore для синхронизации.

<a name='M-Study-LabWork2-Feature-Task1-SubTask1-SemaphoreService-CountPrimes-System-Int32,System-Int32,System-Int32-'></a>
### CountPrimes() `method`

##### Summary

Запускает подсчет простых чисел в заданном диапазоне.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-Feature-Task1-SubTask1-SemaphoreService-GetVersionName'></a>
### GetVersionName() `method`

##### Summary

Возвращает название версии счетчика.

##### Parameters

This method has no parameters.

<a name='T-Study-LabWork2-Feature-Task2-SynchronousServerRequestApp'></a>
## SynchronousServerRequestApp `type`

##### Namespace

Study.LabWork2.Feature.Task2

##### Summary

Синхронная версия приложения (без использования async/await)

<a name='T-Study-LabWork2-Feature-Task1-SubTask1-TaskRun1_1'></a>
## TaskRun1_1 `type`

##### Namespace

Study.LabWork2.Feature.Task1.SubTask1

<a name='M-Study-LabWork2-Feature-Task1-SubTask1-TaskRun1_1-Run'></a>
### Run() `method`

##### Summary

Запускает все три версии подсчёта простых чисел.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-Feature-Task1-SubTask1-TaskRun1_1-RunService-Study-LabWork2-Abstractions-Feature-Task1-SubTask1-IPrimeCounter,System-Int32,System-Int32,System-Int32-'></a>
### RunService() `method`

##### Summary

Запускает один сервис и выводит его результат.

##### Parameters

This method has no parameters.

<a name='T-Study-LabWork2-Feature-Task1-SubTask2-TaskRun1_2'></a>
## TaskRun1_2 `type`

##### Namespace

Study.LabWork2.Feature.Task1.SubTask2

<a name='M-Study-LabWork2-Feature-Task1-SubTask2-TaskRun1_2-Run'></a>
### Run() `method`

##### Summary

Запускает задание 1.2: многопоточный подсчёт сумм наборов.

##### Parameters

This method has no parameters.
