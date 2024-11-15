import React, { useState } from 'react'
import { Form, Col, Row, Button } from 'react-bootstrap';

const WaitingRoom = ({joinChatRoom}) => {
  const[userName, setUserName] = useState();
  const[chatRoom, setChatRoom] = useState();
  return (
    <Form onSubmit={(e) => {
      e.preventDefault()
      joinChatRoom(userName, chatRoom)
    }}>
      <Row className='px-5 py-5'>
        <Col sm={12}>
          <Form.Group>
            <Form.Control placeholder='User Name' onChange={e => setUserName(e.target.value)} />
            <Form.Control placeholder='Chat Room' onChange={e => setChatRoom(e.target.value)} />
          </Form.Group>
        </Col>
        <Col sm={12}>
          <hr/>
          <Button variant='success' type='submit'>Join</Button>
        </Col>
      </Row>
    </Form>
  )
}

export default WaitingRoom