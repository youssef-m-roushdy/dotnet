import 'bootstrap/dist/css/bootstrap.min.css'
import { Col, Container, Row } from 'react-bootstrap'
import './App.css';
import WaitingRoom from './components/WaitingRoom';
import { useState } from 'react';
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr'

function App() {
  const[conn, setConnection] = useState();

  const joinChatRoom = async (userName, chatRoom) => {
    try {
      const conn = new HubConnectionBuilder()
      .withUrl('http://localhost:5148/chat')
      .configureLogging(LogLevel.Information)
      .build();

      conn.on('JoinSpecificChatRoom', (userName, msg) => {
        console.log("msg: ", msg)
      })

      await conn.start()
      await conn.invoke('JoinSpecificChatRoom', {userName, chatRoom})

      setConnection(conn)
    } catch (error) {
      
    }
  }
  return (
    <div className="App">
      <main>
        <Container>
          <Row className='px-5 my-5'>
            <Col className="sm-12">
              <h1 className='font-weight-light'>Welcome to the Chatyy App</h1>
            </Col>
          </Row>
          <WaitingRoom joinChatRoom={joinChatRoom}/>
        </Container>
      </main>
    </div>
  );
}

export default App;
