import 'bootstrap/dist/css/bootstrap.min.css'
import { Col, Container, Row } from 'react-bootstrap'
import './App.css';
import WaitingRoom from './components/WaitingRoom';
import { useState } from 'react';
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr'
import ChatRoom from './components/ChatRoom';

function App() {
  // React state hook to manage the connection to the SignalR hub
const [conn, setConnection] = useState();

// React state hook to manage the list of messages
const [messages, setMessages] = useState([]);

  // Function to join a specific chat room
  const joinChatRoom = async (userName, chatRoom) => {
    try {
      // Create a new SignalR connection instance
      const conn = new HubConnectionBuilder()
        .withUrl('http://localhost:5148/chat') // URL of the SignalR hub
        .configureLogging(LogLevel.Information) // Set logging level to monitor connection activity
        .build();

      // Event handler for when the user joins a specific chat room
      conn.on('JoinSpecificChatRoom', (userName, msg) => {
        // Update the messages state with the new message
        setMessages(messages => [...messages, { userName, msg }]);
      });

      // Event handler for receiving messages sent to the chat room
      conn.on("ReceiveSpecificMessage", (userName, msg) => {
        // Update the messages state with the new message
        setMessages(messages => [...messages, { userName, msg }]);
      });

      // Start the SignalR connection
      await conn.start();

      // Invoke the "JoinSpecificChatRoom" method on the server with user details
      await conn.invoke('JoinSpecificChatRoom', { userName, chatRoom });

      // Save the active connection instance in state
      setConnection(conn);
    } catch (e) {
      // Log any errors that occur during the connection or method invocation
      console.log(e);
    }
  };

// Function to send a message to the current chat room
  const sendMessage = async (message) => {
    try {
      // Invoke the "SendMessage" method on the server with the message content
      await conn.invoke("SendMessage", message);
    } catch (e) {
      // Log any errors that occur while sending the message
      console.log(e);
    }
  };


  return (
    <div className="App">
      <main>
        <Container>
          <Row className='px-5 my-5'>
            <Col className="sm-12">
              <h1 className='font-weight-light'>Welcome to the Chatyy App</h1>
            </Col>
          </Row>
          {!conn 
          ?(<WaitingRoom joinChatRoom={joinChatRoom}/>)
          :(<ChatRoom messages={messages} sendMessage={sendMessage}/>)
          }
          
        </Container>
      </main>
    </div>
  );
}

export default App;
