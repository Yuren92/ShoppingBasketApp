# ShoppingBasketApp

A simple C# console application that simulates filling a shopping basket using a "heaviest-first" strategy.

## Features

- Items are selected based on weight, starting from the heaviest.
- The basket has a maximum capacity of 20 kg.
- Handles edge cases like:
  - Empty shopping list
  - Invalid items (null, negative or zero weight, over 20 kg)
- Provides clear messages and total weight.

## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

## How to Run

1. Open a terminal in the project folder.
2. Run:

```bash
dotnet build
dotnet run
```

## Example Output

```
--- Test 1: Standard shopping list ---
Basket filled using heaviest-first strategy.
 - Rice Bag (10 kg)
 - Watermelon (5 kg)
 - Olive Oil (4.5 kg)
Total weight: 19.5 kg
```

## Author

Pedro Ballesta – for technical test purposes.