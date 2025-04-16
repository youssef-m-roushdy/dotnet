
# 🌐 gRPC CRUD API باستخدام ASP.NET Core

## 🚀 نظرة عامة
هذا المشروع عبارة عن API باستخدام gRPC و ASP.NET Core لتنفيذ عمليات CRUD (إنشاء، قراءة، تحديث، حذف) على بيانات معينة مثل المستخدمين أو المنتجات أو أي كيان آخر.

gRPC بيستخدم Protocol Buffers لتمثيل البيانات، وبيشتغل بكفاءة عالية خاصة في أنظمة Microservices.

---

## 📁 هيكل المشروع

```bash
.
├── Protos/                 # ملفات .proto لتعريف الخدمات والرسائل
│   └── greet.proto
│   └── product.proto
├── Services/               # كلاس الخدمة gRPC
│   └── GreeterService.cs
│   └── ProductService.cs
├── Program.cs              # نقطة بدء المشروع
├── Startup.cs              # تكوين الخدمة و gRPC
└── README.md
```

---

## 📄 ملف .proto

```proto
syntax = "proto3";

option csharp_namespace = "GrpcCrudService";

package product;

// تعريف الرسائل(DTOs)
message Product {
    int32 id = 1;
    string name = 2;
    string description = 3;
    double price = 4;
}

message GetProductRequest {
    int32 id = 1;
}

message ProductListResponse {
    repeated Product products = 1;
}

message CreateProductRequest {
    string name = 1;
    string description = 2;
    double price = 3;
}

message UpdateProductRequest {
    int32 id = 1;
    string name = 2;
    string description = 3;
    double price = 4;
}

message DeleteProductRequest {
    int32 id = 1;
}

// تعريف الخدمة(Interface)
service ProductProtoService {
    rpc GetProduct(GetProductRequest) returns (Product);
    rpc ListProduct(google.protobuf.Empty) returns (ProductListResponse);
    rpc CreateProduct(CreateProductRequest) returns (Product);
    rpc UpdateProduct(UpdateProductRequest) returns (Product);
    rpc DeleteProduct(DeleteProductRequest) returns (google.protobuf.Empty);
}
```

---

## ⚙️ خطوات التشغيل

### 1. إنشاء المشروع:
```
dotnet new grpc -o GrpcCrudApiDemo
cd GrpcCrudApiDemo
```

### 2. إضافة ملف .proto في مجلد `Protos/`

### 3. تسجيل الخدمة داخل `Startup.cs` (أو Program.cs في .NET 6+):
```
app.MapGrpcService<CrudService>();
```

### 4. تشغيل المشروع:
```
dotnet run
```

---

## 🧪 اختبار gRPC

- استخدم أداة مثل [Postman](https://www.postman.com/) (تدعم gRPC) أو
- استخدم `grpcurl`:
```
grpcurl -plaintext localhost:5000 list
```

---

## 📌 ملاحظات

- تأكد من أنك مفعّل SSL/TLS في الإنتاج.
- تأكد من توثيق API وخدماتها للاستخدام الداخلي أو الخارجي.

---

## 🤝 المساهمة

لو عندك أفكار أو تحسينات، افتح Pull Request أو Issue ✨

## Support Http1AndHttp2 issue

sometimes when use it only support Http1 so to fix it

### Make Http1 and Http2 works on different ports in your appsetting.json
```
"Kestrel": {
    "Endpoints": {
      "Http1": {
        "Url": "http://localhost:5000",
        "Protocols": "Http1"
      },
      "Http2": {
        "Url": "http://localhost:5001",
        "Protocols": "Http2"
      }
    }
  }
```

### Test
REST API:
```bash
curl http://localhost:5000/product
```

gRPC:
```bash
grpcurl -plaintext localhost:5001 list
```

