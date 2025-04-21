
# 🐇 مشروع RabbitMQ مع ASP.NET Web API و Console App

## 📝 مقدمة | Introduction

هذا المشروع يوضح استخدام **RabbitMQ** كـ message broker بين تطبيق ASP.NET Web API (الذي يعمل كـ Publisher) وتطبيق Console (الذي يعمل كـ Consumer). يتم تبادل الرسائل عبر **Queues**.

---

## 🧠 ما هو RabbitMQ؟

**RabbitMQ** هو message broker يسمح للتطبيقات المختلفة بالتواصل مع بعضها عن طريق تمرير الرسائل من خلال queues. بدل ما التطبيق يرسل مباشرة لتطبيق آخر، هو يرسل رسالة للـ **queue**، والـ **Consumer** بياخد الرسالة من الـ queue.

---

## 🧭 الأدوار الرئيسية | Main Roles

### 🎙️ Publisher (الناشر)
هو التطبيق اللي بيبعت الرسائل إلى الـ queue. في المشروع ده، هو ASP.NET Web API.

### 🎧 Consumer (المستهلك)
هو التطبيق اللي بيستقبل الرسائل من الـ queue. في المشروع ده، هو Console App.

---

## 🧰 الحزم المطلوبة | Required NuGet Packages

### 📦 Publisher (ASP.NET Web API)

```
Microsoft.AspNetCore.OpenApi" Version="8.0.15"
RabbitMQ.Client" Version="6.4.0"
Swashbuckle.AspNetCore" Version="6.6.2"
```

### 📦 Consumer (Console App)

```
RabbitMQ.Client" Version="6.4.0"
```

---

## 🐳 تشغيل RabbitMQ باستخدام Docker

عشان تشتغل RabbitMQ على جهازك، بنستخدم Docker Compose لتشغيل سيرفر RabbitMQ بسهولة.

### 📄 docker-compose.yml

Fot run RabbitMQ service on docker for test

[docker-compose](./docker-compose.yml)


### 🚀 خطوات التشغيل:

1. احفظ الملف باسم `docker-compose.yml`.
2. افتح التيرمنال وشغل الأمر:
   ```
   docker-compose up -d
   ```
3. افتح المتصفح على الرابط:
   [http://localhost:15672](http://localhost:15672)

---

## 🖥️ RabbitMQ UI Dashboard

واجهة RabbitMQ UI بتقدملك أدوات سهلة لإدارة الـ queues والـ messages.

### 🔐 بيانات الدخول الافتراضية:

- **Username:** `user`
- **Password:** `mypass`

### 📋 أهم الأقسام:

- **Overview:** لمراقبة حالة السيرفر
- **Queues:** عشان تشوف الـ queues النشطة، وعدد الرسائل فيها
- **Exchanges:** لتكوين طريقة توجيه الرسائل للـ queues
- **Connections/Channels:** لرؤية الاتصالات المفتوحة بين التطبيقات و RabbitMQ

---

## 🧪 مثال عملي

### ✅ Publisher (Web API)

```
var factory = new ConnectionFactory()
{ 
    HostName = "localhost",
    UserName = "user",
    Password = "mypass",
    VirtualHost = "/" 
};

using var conn = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "demo-queue", durable: true, exclusive: false);

string message = "Hello RabbitMQ!";
var body = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(exchange: "", routingKey: "demo-queue", basicProperties: null, body: body);
```

### ✅ Consumer (Console App)

```
var factory = new ConnectionFactory()
{ 
    HostName = "localhost",
    UserName = "user",
    Password = "mypass",
    VirtualHost = "/" 
};

using var conn = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "demo-queue", durable: true, exclusive: false);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($" [x] Received: {message}");
};

channel.BasicConsume(queue: "demo-queue", autoAck: true, consumer: consumer);
Console.ReadLine();
```

---

## ✅ ملاحظات مهمة

- تأكد من تشغيل Docker قبل تنفيذ المشروع.
- اسم الـ queue يجب أن يكون موحد بين الـ publisher و consumer.
- تأكد من إعداد الـ connection parameters (`HostName`, `UserName`, `Password`) بشكل صحيح.

---

## 🏁 النتيجة المتوقعة

عند تشغيل الـ API، يتم إرسال رسالة إلى RabbitMQ.  
الـ Console App يقوم بالتقاط الرسالة وطباعة محتواها.
