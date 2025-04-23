
# 📘 LogUpController - Technical Test

## ✅ Objective

The purpose of this technical test is to demonstrate the ability to create a simple ASP.NET Core Web API endpoint that generates and returns a list of log entries with realistic-looking data using the **Bogus** data generation library.

---

## 🔧 Setup Instructions

1. **Clone the repository**  
   ```bash
   git clone https://github.com/your-repo/logup-api.git
   cd logup-api
   ```

2. **Install dependencies**  
   Ensure you have [.NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) or later installed.

   Add the Bogus package:
   ```bash
   dotnet add package Bogus
   ```

3. **Run the project**
   ```bash
   dotnet run
   ```

---

## 🚀 API Endpoint

### `GET /Get`

Returns a list of 10 randomly generated log entries.

#### ✅ Sample Request

```http
GET /Get HTTP/1.1
Host: localhost:{port}
```

#### 📦 Response

Returns `200 OK` with a JSON array of `LogUp` objects:

| Property     | Type       | Description                              |
|--------------|------------|------------------------------------------|
| `Id`         | `Guid`     | Unique identifier for the log            |
| `Title`      | `string`   | Simulated title (e.g., company name)     |
| `CreatedOn`  | `DateTime` | Random date in the past                  |
| `Description`| `string`   | Fake text paragraphs                     |
| `Comments`   | `string`   | Fake comment paragraphs                  |

#### 🧪 Example Response

```json
[
  {
    "id": "3d635a84-2b60-49e7-8c4e-5462ed7f805c",
    "title": "Globex Corporation",
    "createdOn": "2022-11-23T09:12:00",
    "description": "Generated description...",
    "comments": "Some random comments..."
  }
]
```

---

## 📄 LogUpController.cs

```csharp
[ApiController]
[Route("[controller]")]
public class LogUpController : ControllerBase
{
    [HttpGet(Name = "Get")]
    public List<LogUp> Get()
    {
        var logUp = new Faker<LogUp>()
            .RuleFor(p => p.Id, p => Guid.NewGuid())
            .RuleFor(p => p.Title, p => p.Company.CompanyName())
            .RuleFor(p => p.CreatedOn, p => p.Date.Past())
            .RuleFor(p => p.Description, p => p.Lorem.Paragraphs())
            .RuleFor(p => p.Comments, p => p.Lorem.Paragraphs());

        var logUpList = new List<LogUp>();

        for (int i = 0; i < 10; i++)
        {
            logUpList.Add(logUp.Generate());
        }

        return logUpList;
    }
}
```

---

## 📚 Technologies Used

- ASP.NET Core
- Bogus (for fake data generation)
