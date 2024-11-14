import { Col, Container, Row } from 'react-bootstrap';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import { useEffect, useState } from 'react';

function App() {
  const [conn, setConnection] = useState(null);
  const [messages, setMessages] = useState([]);

  useEffect(() => {
    const getNotifications = async () => {
      try {
        const connection = new HubConnectionBuilder()
          .withUrl("http://localhost:5259/notifications")
          .configureLogging(LogLevel.Information)
          .build();
        
        // Set up handler for receiving messages
        connection.on("ReceiveNotification", (msg) => {
          console.log("msg: ", msg);
          setMessages(messages => [...messages, msg]);
        });

        await connection.start(); // Start the connection
        console.log("Connected to Notification Hub");
        setConnection(connection); // Update the connection state

      } catch (e) {
        console.error("Connection failed: ", e);
      }
    };

    getNotifications();

    // Cleanup connection on component unmount
    return () => {
      if (conn) {
        conn.stop();
      }
    };
  }, []); // Empty dependency array to run only once on mount

  return (
    <div>
      <main>
        <Container>
          <Row className="px-5 my-5">
            <Col sm="12">
              <h1 className="font-weight-light">Welcome to the Notification app</h1>
              <ul>
                {messages.map((msg, index) => (
                  <li key={index}>{msg}</li>
                ))}
              </ul>
            </Col>
          </Row>
        </Container>
      </main>
    </div>
  );
}

export default App;
