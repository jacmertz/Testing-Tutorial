# C# Unit Testing — Fan & Set

A C# project demonstrating test-driven development (TDD) using xUnit. Covers two independently tested classes: a `Fan` model with speed/RPM logic, and a `Set` collection with union and intersection operations.

---

## Overview

This project contains two implementation classes and their corresponding xUnit test suites. The implementations were developed alongside the tests to validate boundary enforcement, state consistency, and set math correctness.

---

## File Structure

```
unit-testing/
├── Fan.cs               # Fan model — speed control, on/off state, RPM calculation
├── Set.cs               # Integer set — union, intersection, duplicate prevention
├── FanUnitTests.cs      # xUnit tests for Fan
├── SetUnitTests.cs      # xUnit tests for Set
├── Usings.cs            # Global using directives
└── README.md
```

---

## Classes

### `Fan`
Represents a fan with speeds ranging from `0` to `5`.

- Speed `0` → fan is off; speeds `1–5` → fan is on
- Out-of-range speed assignments are silently ignored (no change)
- RPM is derived from speed: `150 + (speed × 50)`

| Speed | RPM |
|-------|-----|
| 0     | 0   |
| 1     | 200 |
| 2     | 250 |
| 3     | 300 |
| 4     | 350 |
| 5     | 400 |

**Properties:**
- `CurSpeed` — gets/sets the fan speed with boundary enforcement
- `FanOn` — read-only; automatically kept in sync with speed
- `RPM` — read-only; computed from current speed

---

### `Set`
Represents a collection of unique integers. Implements `IEnumerable<int>`.

- Backed by a `HashSet<int>` — duplicates are automatically excluded
- Constructors: empty set and array-initialized set

**Methods:**

| Method | Description |
|--------|-------------|
| `Add(int)` | Adds an element to the set |
| `Union(Set)` | Returns a new set containing all elements from both sets |
| `Intersection(Set)` | Returns a new set containing only elements present in both sets |
| `Count` | Returns the number of elements in the set |

---

## Tests

Tests are written with **xUnit** using both `[Fact]` (single case) and `[Theory]` + `[InlineData]` (parameterized cases).

### `FanUnitTests`

| Test | Description |
|------|-------------|
| `FanShouldBeOffWithSpeed0Initially` | Default state is speed `0`, fan off |
| `SpeedWontChangeIfSetOutside0to5` | Out-of-range values (`-50`, `-1`, `6`, `75`) are rejected |
| `SpeedTo0TurnsFanOff` | Setting speed to `0` turns the fan off |
| `Speed1to5TurnsFanOn` | Speeds `1–5` each turn the fan on |
| `RPMIsCorrect` | Validates RPM output for all valid speeds including `0` |

### `SetUnitTests`

| Test | Description |
|------|-------------|
| `SetUnionIsCorrect` | Validates union across 6 cases including empty sets and overlapping elements |
| `SetIntersectionIsCorrect` | Validates intersection across 6 cases including disjoint and identical sets |

---

## How to Run

```bash
dotnet test
```

Or run via the Visual Studio Test Explorer.

---

## Dependencies

- [xUnit](https://xunit.net/) — test framework
- .NET 6+