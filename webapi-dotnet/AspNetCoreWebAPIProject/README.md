# ASP .NET Web API Project

<b>This Is How To Create Asp .Net Web API Project In CMD</b>

```
dotnet new webapi -n AspNetCoreWebAPIProjectName
```
With Controller-Based
```
dotnet new webapi --use-controllers -o AspNetCoreWebAPIProjectName
```

<b>Run Your Ptoject In CMD</b>

```
dotnet watch run
```

## What Is Controllers

<b>In ASP.NET Core, controllers are classes that handle incoming HTTP requests, process the request, and return a response. They are a key component of the Model-View-Controller (MVC) pattern and serve as the middle layer that communicates between the Model (data layer) and the View (presentation layer).</b>

Key Points about Controllers:

1- <b>Purpose</b>:

* Handle user input (usually HTTP requests).
* Invoke appropriate business logic (e.g., services or database interactions).
* Return the response in various formats (JSON, HTML, XML, etc.).

2- <b>Structure</b>:

* Controllers are typically located in the Controllers folder of an ASP.NET Core project.
* They inherit from the ControllerBase class (for APIs) or Controller class (for APIs and views).

3- <b>Attributes</b>:

* Use routing attributes like [Route], [HttpGet], [HttpPost], etc., to map HTTP requests to specific methods.

<b>Example</b>:
```
[ApiController]
[Route("api/[controller]")]
public class ProductsController : Controller
{
    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        // Retrieve the product by ID
    }
}
```

4- <b>Method Actions</b>:

* Controllers consist of action methods that handle specific HTTP verbs (GET, POST, PUT, DELETE, etc.).
* Each method in the controller corresponds to an endpoint for the API or web application.

5- <b>Response Types</b>:

* Return types of actions can include:
  * JSON or XML for API responses (e.g., using Ok, Created, BadRequest).
  * Views for web applications (e.g., using View).

### Types of Controllers:

1- <b>API Controllers</b>:

* Handle RESTful APIs.
* Typically return data in JSON format.
* Use the [ApiController] attribute for automatic validation and other API-related behaviors.

<b>Example</b>:

```
[ApiController]
[Route("api/[controller]")]
public class ProductsController : Controller
{
    [HttpGet]
    public IActionResult GetAllProducts()
    {
        return Ok(products);
    }
}
```

2- <b>MVC Controllers</b>:

Handle web applications with views (HTML pages).
Can render views using the View method.
Inherit from the Controller class.

<b>Example</b>:

```
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
```

<b>Example</b>: API Controller

```
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private static List<Product> products = new List<Product>();

    [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok(products);
    }

    [HttpPost]
    public IActionResult AddProduct(Product product)
    {
        products.Add(product);
        return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return NotFound();
        return Ok(product);
    }
}
```

<b>Benefits of Controllers</b>:

* Separation of Concerns: Keep the code for request handling separate from data and UI logic.
* Reusability: Centralize and reuse logic for handling requests.
* Testability: Easier to unit test by mocking dependencies.