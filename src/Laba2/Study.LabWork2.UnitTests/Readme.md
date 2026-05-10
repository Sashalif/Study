<a name='assembly'></a>
# Study.LabWork2.UnitTests

## Contents

- [MonitorServiceTests](#T-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MonitorServiceTests 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.MonitorServiceTests')
  - [CountPrimes_FullRange_ShouldReturn1229Primes()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MonitorServiceTests-CountPrimes_FullRange_ShouldReturn1229Primes 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.MonitorServiceTests.CountPrimes_FullRange_ShouldReturn1229Primes')
  - [CountPrimes_MultipleInvocations_ShouldReturnSameResult()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MonitorServiceTests-CountPrimes_MultipleInvocations_ShouldReturnSameResult 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.MonitorServiceTests.CountPrimes_MultipleInvocations_ShouldReturnSameResult')
  - [CountPrimes_MultipleThreads_ShouldReturnCorrectResult()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MonitorServiceTests-CountPrimes_MultipleThreads_ShouldReturnCorrectResult 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.MonitorServiceTests.CountPrimes_MultipleThreads_ShouldReturnCorrectResult')
  - [CountPrimes_RangeWithoutPrimes_ShouldReturnZero()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MonitorServiceTests-CountPrimes_RangeWithoutPrimes_ShouldReturnZero 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.MonitorServiceTests.CountPrimes_RangeWithoutPrimes_ShouldReturnZero')
  - [CountPrimes_SingleThread_ShouldPreserveOrder()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MonitorServiceTests-CountPrimes_SingleThread_ShouldPreserveOrder 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.MonitorServiceTests.CountPrimes_SingleThread_ShouldPreserveOrder')
  - [CountPrimes_SmallRangeSingleThread_ShouldReturnCorrectResult()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MonitorServiceTests-CountPrimes_SmallRangeSingleThread_ShouldReturnCorrectResult 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.MonitorServiceTests.CountPrimes_SmallRangeSingleThread_ShouldReturnCorrectResult')
  - [IsValid_WithCorrectExpectedCount_ShouldReturnTrue()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MonitorServiceTests-IsValid_WithCorrectExpectedCount_ShouldReturnTrue 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.MonitorServiceTests.IsValid_WithCorrectExpectedCount_ShouldReturnTrue')
  - [IsValid_WithIncorrectExpectedCount_ShouldReturnFalse()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MonitorServiceTests-IsValid_WithIncorrectExpectedCount_ShouldReturnFalse 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.MonitorServiceTests.IsValid_WithIncorrectExpectedCount_ShouldReturnFalse')
  - [SetUp()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MonitorServiceTests-SetUp 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.MonitorServiceTests.SetUp')
- [MutexServiceTests](#T-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MutexServiceTests 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.MutexServiceTests')
  - [CountPrimes_FullRange_ShouldReturn1229Primes()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MutexServiceTests-CountPrimes_FullRange_ShouldReturn1229Primes 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.MutexServiceTests.CountPrimes_FullRange_ShouldReturn1229Primes')
  - [CountPrimes_MultipleInvocations_ShouldReturnSameResult()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MutexServiceTests-CountPrimes_MultipleInvocations_ShouldReturnSameResult 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.MutexServiceTests.CountPrimes_MultipleInvocations_ShouldReturnSameResult')
  - [CountPrimes_MultipleThreads_ShouldReturnCorrectResult()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MutexServiceTests-CountPrimes_MultipleThreads_ShouldReturnCorrectResult 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.MutexServiceTests.CountPrimes_MultipleThreads_ShouldReturnCorrectResult')
  - [CountPrimes_RangeWithoutPrimes_ShouldReturnZero()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MutexServiceTests-CountPrimes_RangeWithoutPrimes_ShouldReturnZero 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.MutexServiceTests.CountPrimes_RangeWithoutPrimes_ShouldReturnZero')
  - [CountPrimes_ResultDto_ShouldHaveCorrectMetadata()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MutexServiceTests-CountPrimes_ResultDto_ShouldHaveCorrectMetadata 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.MutexServiceTests.CountPrimes_ResultDto_ShouldHaveCorrectMetadata')
  - [CountPrimes_SmallRangeSingleThread_ShouldReturnCorrectResult()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MutexServiceTests-CountPrimes_SmallRangeSingleThread_ShouldReturnCorrectResult 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.MutexServiceTests.CountPrimes_SmallRangeSingleThread_ShouldReturnCorrectResult')
  - [GetVersionName_ShouldReturnMutex()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MutexServiceTests-GetVersionName_ShouldReturnMutex 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.MutexServiceTests.GetVersionName_ShouldReturnMutex')
  - [IsValid_WithCorrectExpectedCount_ShouldReturnTrue()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MutexServiceTests-IsValid_WithCorrectExpectedCount_ShouldReturnTrue 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.MutexServiceTests.IsValid_WithCorrectExpectedCount_ShouldReturnTrue')
  - [IsValid_WithIncorrectExpectedCount_ShouldReturnFalse()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MutexServiceTests-IsValid_WithIncorrectExpectedCount_ShouldReturnFalse 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.MutexServiceTests.IsValid_WithIncorrectExpectedCount_ShouldReturnFalse')
  - [Service_ShouldImplementIPrimeCounter()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MutexServiceTests-Service_ShouldImplementIPrimeCounter 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.MutexServiceTests.Service_ShouldImplementIPrimeCounter')
  - [SetUp()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MutexServiceTests-SetUp 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.MutexServiceTests.SetUp')
- [NumberSetProcessorTests](#T-Study-LabWork2-UnitTests-Feature-Task1-SubTask2-NumberSetProcessorTests 'Study.LabWork2.UnitTests.Feature.Task1.SubTask2.NumberSetProcessorTests')
  - [Constructor_WithNullDataSets_ShouldThrowArgumentNullException()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask2-NumberSetProcessorTests-Constructor_WithNullDataSets_ShouldThrowArgumentNullException 'Study.LabWork2.UnitTests.Feature.Task1.SubTask2.NumberSetProcessorTests.Constructor_WithNullDataSets_ShouldThrowArgumentNullException')
  - [Constructor_WithValidParameters_ShouldCreateInstance()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask2-NumberSetProcessorTests-Constructor_WithValidParameters_ShouldCreateInstance 'Study.LabWork2.UnitTests.Feature.Task1.SubTask2.NumberSetProcessorTests.Constructor_WithValidParameters_ShouldCreateInstance')
  - [CreateTestDataSets()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask2-NumberSetProcessorTests-CreateTestDataSets 'Study.LabWork2.UnitTests.Feature.Task1.SubTask2.NumberSetProcessorTests.CreateTestDataSets')
  - [GetResult_BeforeProcess_ShouldThrowInvalidOperationException()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask2-NumberSetProcessorTests-GetResult_BeforeProcess_ShouldThrowInvalidOperationException 'Study.LabWork2.UnitTests.Feature.Task1.SubTask2.NumberSetProcessorTests.GetResult_BeforeProcess_ShouldThrowInvalidOperationException')
  - [Process_EachResult_ShouldHaveCorrectSetNumber()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask2-NumberSetProcessorTests-Process_EachResult_ShouldHaveCorrectSetNumber 'Study.LabWork2.UnitTests.Feature.Task1.SubTask2.NumberSetProcessorTests.Process_EachResult_ShouldHaveCorrectSetNumber')
  - [Process_ShouldCalculateCorrectSums()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask2-NumberSetProcessorTests-Process_ShouldCalculateCorrectSums 'Study.LabWork2.UnitTests.Feature.Task1.SubTask2.NumberSetProcessorTests.Process_ShouldCalculateCorrectSums')
  - [Process_ShouldCalculateCorrectTotalSum()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask2-NumberSetProcessorTests-Process_ShouldCalculateCorrectTotalSum 'Study.LabWork2.UnitTests.Feature.Task1.SubTask2.NumberSetProcessorTests.Process_ShouldCalculateCorrectTotalSum')
  - [Process_ShouldSetCorrectProcessedSetsCount()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask2-NumberSetProcessorTests-Process_ShouldSetCorrectProcessedSetsCount 'Study.LabWork2.UnitTests.Feature.Task1.SubTask2.NumberSetProcessorTests.Process_ShouldSetCorrectProcessedSetsCount')
  - [Process_ShouldSetNonZeroExecutionTime()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask2-NumberSetProcessorTests-Process_ShouldSetNonZeroExecutionTime 'Study.LabWork2.UnitTests.Feature.Task1.SubTask2.NumberSetProcessorTests.Process_ShouldSetNonZeroExecutionTime')
  - [Process_WithEmptyArray_ShouldReturnZeroSum()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask2-NumberSetProcessorTests-Process_WithEmptyArray_ShouldReturnZeroSum 'Study.LabWork2.UnitTests.Feature.Task1.SubTask2.NumberSetProcessorTests.Process_WithEmptyArray_ShouldReturnZeroSum')
  - [Process_WithMoreThreadsThanSets_ShouldWorkCorrectly()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask2-NumberSetProcessorTests-Process_WithMoreThreadsThanSets_ShouldWorkCorrectly 'Study.LabWork2.UnitTests.Feature.Task1.SubTask2.NumberSetProcessorTests.Process_WithMoreThreadsThanSets_ShouldWorkCorrectly')
  - [Process_WithSingleSet_ShouldReturnCorrectResult()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask2-NumberSetProcessorTests-Process_WithSingleSet_ShouldReturnCorrectResult 'Study.LabWork2.UnitTests.Feature.Task1.SubTask2.NumberSetProcessorTests.Process_WithSingleSet_ShouldReturnCorrectResult')
  - [Process_WithSingleThread_ShouldWorkCorrectly()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask2-NumberSetProcessorTests-Process_WithSingleThread_ShouldWorkCorrectly 'Study.LabWork2.UnitTests.Feature.Task1.SubTask2.NumberSetProcessorTests.Process_WithSingleThread_ShouldWorkCorrectly')
- [SemaphoreServiceTests](#T-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-SemaphoreServiceTests 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.SemaphoreServiceTests')
  - [CountPrimes_FullRange_ShouldReturn1229Primes()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-SemaphoreServiceTests-CountPrimes_FullRange_ShouldReturn1229Primes 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.SemaphoreServiceTests.CountPrimes_FullRange_ShouldReturn1229Primes')
  - [CountPrimes_MultipleInvocations_ShouldReturnSameResult()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-SemaphoreServiceTests-CountPrimes_MultipleInvocations_ShouldReturnSameResult 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.SemaphoreServiceTests.CountPrimes_MultipleInvocations_ShouldReturnSameResult')
  - [CountPrimes_MultipleThreads_ShouldReturnCorrectResult()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-SemaphoreServiceTests-CountPrimes_MultipleThreads_ShouldReturnCorrectResult 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.SemaphoreServiceTests.CountPrimes_MultipleThreads_ShouldReturnCorrectResult')
  - [CountPrimes_RangeWithoutPrimes_ShouldReturnZero()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-SemaphoreServiceTests-CountPrimes_RangeWithoutPrimes_ShouldReturnZero 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.SemaphoreServiceTests.CountPrimes_RangeWithoutPrimes_ShouldReturnZero')
  - [CountPrimes_ResultDto_ShouldHaveCorrectMetadata()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-SemaphoreServiceTests-CountPrimes_ResultDto_ShouldHaveCorrectMetadata 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.SemaphoreServiceTests.CountPrimes_ResultDto_ShouldHaveCorrectMetadata')
  - [CountPrimes_SmallRangeSingleThread_ShouldReturnCorrectResult()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-SemaphoreServiceTests-CountPrimes_SmallRangeSingleThread_ShouldReturnCorrectResult 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.SemaphoreServiceTests.CountPrimes_SmallRangeSingleThread_ShouldReturnCorrectResult')
  - [GetVersionName_ShouldReturnSemaphore()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-SemaphoreServiceTests-GetVersionName_ShouldReturnSemaphore 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.SemaphoreServiceTests.GetVersionName_ShouldReturnSemaphore')
  - [IsValid_WithCorrectExpectedCount_ShouldReturnTrue()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-SemaphoreServiceTests-IsValid_WithCorrectExpectedCount_ShouldReturnTrue 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.SemaphoreServiceTests.IsValid_WithCorrectExpectedCount_ShouldReturnTrue')
  - [IsValid_WithIncorrectExpectedCount_ShouldReturnFalse()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-SemaphoreServiceTests-IsValid_WithIncorrectExpectedCount_ShouldReturnFalse 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.SemaphoreServiceTests.IsValid_WithIncorrectExpectedCount_ShouldReturnFalse')
  - [Service_ShouldImplementIPrimeCounter()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-SemaphoreServiceTests-Service_ShouldImplementIPrimeCounter 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.SemaphoreServiceTests.Service_ShouldImplementIPrimeCounter')
  - [SetUp()](#M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-SemaphoreServiceTests-SetUp 'Study.LabWork2.UnitTests.Feature.Task1.SubTask1.SemaphoreServiceTests.SetUp')

<a name='T-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MonitorServiceTests'></a>
## MonitorServiceTests `type`

##### Namespace

Study.LabWork2.UnitTests.Feature.Task1.SubTask1

##### Summary

Тесты для версии с Monitor (lock).

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MonitorServiceTests-CountPrimes_FullRange_ShouldReturn1229Primes'></a>
### CountPrimes_FullRange_ShouldReturn1229Primes() `method`

##### Summary

Проверяет подсчёт в полном диапазоне от 1 до 10000.
Ожидаемое количество простых чисел: 1229.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MonitorServiceTests-CountPrimes_MultipleInvocations_ShouldReturnSameResult'></a>
### CountPrimes_MultipleInvocations_ShouldReturnSameResult() `method`

##### Summary

Проверяет, что несколько запусков с одинаковыми параметрами дают одинаковый результат.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MonitorServiceTests-CountPrimes_MultipleThreads_ShouldReturnCorrectResult'></a>
### CountPrimes_MultipleThreads_ShouldReturnCorrectResult() `method`

##### Summary

Проверяет корректность подсчёта с несколькими потоками.
Все потоки вместе должны найти все простые числа в диапазоне.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MonitorServiceTests-CountPrimes_RangeWithoutPrimes_ShouldReturnZero'></a>
### CountPrimes_RangeWithoutPrimes_ShouldReturnZero() `method`

##### Summary

Проверяет, что в диапазоне без простых чисел возвращается 0.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MonitorServiceTests-CountPrimes_SingleThread_ShouldPreserveOrder'></a>
### CountPrimes_SingleThread_ShouldPreserveOrder() `method`

##### Summary

Проверяет, что при одном потоке простые числа сохраняют порядок в FoundPrimes.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MonitorServiceTests-CountPrimes_SmallRangeSingleThread_ShouldReturnCorrectResult'></a>
### CountPrimes_SmallRangeSingleThread_ShouldReturnCorrectResult() `method`

##### Summary

Проверяет корректность подсчёта в небольшом диапазоне с одним потоком.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MonitorServiceTests-IsValid_WithCorrectExpectedCount_ShouldReturnTrue'></a>
### IsValid_WithCorrectExpectedCount_ShouldReturnTrue() `method`

##### Summary

Проверяет, что метод IsValid возвращает true при совпадении.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MonitorServiceTests-IsValid_WithIncorrectExpectedCount_ShouldReturnFalse'></a>
### IsValid_WithIncorrectExpectedCount_ShouldReturnFalse() `method`

##### Summary

Проверяет, что метод IsValid возвращает false при несовпадении.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MonitorServiceTests-SetUp'></a>
### SetUp() `method`

##### Summary

Инициализация перед каждым тестом.

##### Parameters

This method has no parameters.

<a name='T-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MutexServiceTests'></a>
## MutexServiceTests `type`

##### Namespace

Study.LabWork2.UnitTests.Feature.Task1.SubTask1

##### Summary

Тесты для версии с Mutex.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MutexServiceTests-CountPrimes_FullRange_ShouldReturn1229Primes'></a>
### CountPrimes_FullRange_ShouldReturn1229Primes() `method`

##### Summary

Проверяет подсчёт в полном диапазоне от 1 до 10000.
Ожидаемое количество простых чисел: 1229.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MutexServiceTests-CountPrimes_MultipleInvocations_ShouldReturnSameResult'></a>
### CountPrimes_MultipleInvocations_ShouldReturnSameResult() `method`

##### Summary

Проверяет, что несколько запусков с одинаковыми параметрами дают одинаковый результат.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MutexServiceTests-CountPrimes_MultipleThreads_ShouldReturnCorrectResult'></a>
### CountPrimes_MultipleThreads_ShouldReturnCorrectResult() `method`

##### Summary

Проверяет корректность подсчёта с несколькими потоками.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MutexServiceTests-CountPrimes_RangeWithoutPrimes_ShouldReturnZero'></a>
### CountPrimes_RangeWithoutPrimes_ShouldReturnZero() `method`

##### Summary

Проверяет, что в диапазоне без простых чисел возвращается 0.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MutexServiceTests-CountPrimes_ResultDto_ShouldHaveCorrectMetadata'></a>
### CountPrimes_ResultDto_ShouldHaveCorrectMetadata() `method`

##### Summary

Проверяет, что DTO содержит правильные метаданные.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MutexServiceTests-CountPrimes_SmallRangeSingleThread_ShouldReturnCorrectResult'></a>
### CountPrimes_SmallRangeSingleThread_ShouldReturnCorrectResult() `method`

##### Summary

Проверяет корректность подсчёта в небольшом диапазоне с одним потоком.
Ожидаемые простые числа от 1 до 10: 2, 3, 5, 7 (всего 4).

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MutexServiceTests-GetVersionName_ShouldReturnMutex'></a>
### GetVersionName_ShouldReturnMutex() `method`

##### Summary

Проверяет, что GetVersionName возвращает правильное название.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MutexServiceTests-IsValid_WithCorrectExpectedCount_ShouldReturnTrue'></a>
### IsValid_WithCorrectExpectedCount_ShouldReturnTrue() `method`

##### Summary

Проверяет, что метод IsValid возвращает true при совпадении.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MutexServiceTests-IsValid_WithIncorrectExpectedCount_ShouldReturnFalse'></a>
### IsValid_WithIncorrectExpectedCount_ShouldReturnFalse() `method`

##### Summary

Проверяет, что метод IsValid возвращает false при несовпадении.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MutexServiceTests-Service_ShouldImplementIPrimeCounter'></a>
### Service_ShouldImplementIPrimeCounter() `method`

##### Summary

Проверяет, что сервис реализует интерфейс IPrimeCounter.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-MutexServiceTests-SetUp'></a>
### SetUp() `method`

##### Summary

Инициализация перед каждым тестом.

##### Parameters

This method has no parameters.

<a name='T-Study-LabWork2-UnitTests-Feature-Task1-SubTask2-NumberSetProcessorTests'></a>
## NumberSetProcessorTests `type`

##### Namespace

Study.LabWork2.UnitTests.Feature.Task1.SubTask2

##### Summary

Проверяет многопоточную обработку наборов чисел

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask2-NumberSetProcessorTests-Constructor_WithNullDataSets_ShouldThrowArgumentNullException'></a>
### Constructor_WithNullDataSets_ShouldThrowArgumentNullException() `method`

##### Summary

Проверяет, что конструктор выбрасывает исключение при null вместо наборов.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask2-NumberSetProcessorTests-Constructor_WithValidParameters_ShouldCreateInstance'></a>
### Constructor_WithValidParameters_ShouldCreateInstance() `method`

##### Summary

Проверяет, что конструктор не выбрасывает исключение при корректных параметрах.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask2-NumberSetProcessorTests-CreateTestDataSets'></a>
### CreateTestDataSets() `method`

##### Summary

Создаёт тестовые наборы: 5 наборов по 3 числа.
Суммы: [6, 15, 24, 33, 42], общая = 120.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask2-NumberSetProcessorTests-GetResult_BeforeProcess_ShouldThrowInvalidOperationException'></a>
### GetResult_BeforeProcess_ShouldThrowInvalidOperationException() `method`

##### Summary

Проверяет, что GetResult выбрасывает исключение, если Process не был вызван.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask2-NumberSetProcessorTests-Process_EachResult_ShouldHaveCorrectSetNumber'></a>
### Process_EachResult_ShouldHaveCorrectSetNumber() `method`

##### Summary

Проверяет, что каждый результат содержит корректный номер набора.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask2-NumberSetProcessorTests-Process_ShouldCalculateCorrectSums'></a>
### Process_ShouldCalculateCorrectSums() `method`

##### Summary

Проверяет, что суммы всех наборов считаются правильно.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask2-NumberSetProcessorTests-Process_ShouldCalculateCorrectTotalSum'></a>
### Process_ShouldCalculateCorrectTotalSum() `method`

##### Summary

Проверяет, что общая сумма считается правильно.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask2-NumberSetProcessorTests-Process_ShouldSetCorrectProcessedSetsCount'></a>
### Process_ShouldSetCorrectProcessedSetsCount() `method`

##### Summary

Проверяет, что количество обработанных наборов совпадает с количеством входных.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask2-NumberSetProcessorTests-Process_ShouldSetNonZeroExecutionTime'></a>
### Process_ShouldSetNonZeroExecutionTime() `method`

##### Summary

Проверяет, что время выполнения больше нуля.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask2-NumberSetProcessorTests-Process_WithEmptyArray_ShouldReturnZeroSum'></a>
### Process_WithEmptyArray_ShouldReturnZeroSum() `method`

##### Summary

Проверяет обработку набора с пустым массивом чисел.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask2-NumberSetProcessorTests-Process_WithMoreThreadsThanSets_ShouldWorkCorrectly'></a>
### Process_WithMoreThreadsThanSets_ShouldWorkCorrectly() `method`

##### Summary

Проверяет, что при количестве потоков больше, чем наборов, работает корректно.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask2-NumberSetProcessorTests-Process_WithSingleSet_ShouldReturnCorrectResult'></a>
### Process_WithSingleSet_ShouldReturnCorrectResult() `method`

##### Summary

Проверяет обработку единственного набора.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask2-NumberSetProcessorTests-Process_WithSingleThread_ShouldWorkCorrectly'></a>
### Process_WithSingleThread_ShouldWorkCorrectly() `method`

##### Summary

Проверяет, что при 1 потоке все наборы обрабатываются последовательно.

##### Parameters

This method has no parameters.

<a name='T-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-SemaphoreServiceTests'></a>
## SemaphoreServiceTests `type`

##### Namespace

Study.LabWork2.UnitTests.Feature.Task1.SubTask1

##### Summary

Тесты для версии с Semaphore.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-SemaphoreServiceTests-CountPrimes_FullRange_ShouldReturn1229Primes'></a>
### CountPrimes_FullRange_ShouldReturn1229Primes() `method`

##### Summary

Проверяет подсчёт в полном диапазоне от 1 до 10000.
Ожидаемое количество простых чисел: 1229.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-SemaphoreServiceTests-CountPrimes_MultipleInvocations_ShouldReturnSameResult'></a>
### CountPrimes_MultipleInvocations_ShouldReturnSameResult() `method`

##### Summary

Проверяет, что несколько запусков с одинаковыми параметрами дают одинаковый результат.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-SemaphoreServiceTests-CountPrimes_MultipleThreads_ShouldReturnCorrectResult'></a>
### CountPrimes_MultipleThreads_ShouldReturnCorrectResult() `method`

##### Summary

Проверяет корректность подсчёта с несколькими потоками.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-SemaphoreServiceTests-CountPrimes_RangeWithoutPrimes_ShouldReturnZero'></a>
### CountPrimes_RangeWithoutPrimes_ShouldReturnZero() `method`

##### Summary

Проверяет, что в диапазоне без простых чисел возвращается 0.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-SemaphoreServiceTests-CountPrimes_ResultDto_ShouldHaveCorrectMetadata'></a>
### CountPrimes_ResultDto_ShouldHaveCorrectMetadata() `method`

##### Summary

Проверяет, что DTO содержит правильные метаданные.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-SemaphoreServiceTests-CountPrimes_SmallRangeSingleThread_ShouldReturnCorrectResult'></a>
### CountPrimes_SmallRangeSingleThread_ShouldReturnCorrectResult() `method`

##### Summary

Проверяет корректность подсчёта в небольшом диапазоне с одним потоком.
Ожидаемые простые числа от 1 до 10: 2, 3, 5, 7 (всего 4).

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-SemaphoreServiceTests-GetVersionName_ShouldReturnSemaphore'></a>
### GetVersionName_ShouldReturnSemaphore() `method`

##### Summary

Проверяет, что GetVersionName возвращает правильное название.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-SemaphoreServiceTests-IsValid_WithCorrectExpectedCount_ShouldReturnTrue'></a>
### IsValid_WithCorrectExpectedCount_ShouldReturnTrue() `method`

##### Summary

Проверяет, что метод IsValid возвращает true при совпадении.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-SemaphoreServiceTests-IsValid_WithIncorrectExpectedCount_ShouldReturnFalse'></a>
### IsValid_WithIncorrectExpectedCount_ShouldReturnFalse() `method`

##### Summary

Проверяет, что метод IsValid возвращает false при несовпадении.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-SemaphoreServiceTests-Service_ShouldImplementIPrimeCounter'></a>
### Service_ShouldImplementIPrimeCounter() `method`

##### Summary

Проверяет, что сервис реализует интерфейс IPrimeCounter.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-UnitTests-Feature-Task1-SubTask1-SemaphoreServiceTests-SetUp'></a>
### SetUp() `method`

##### Summary

Инициализация перед каждым тестом.

##### Parameters

This method has no parameters.
