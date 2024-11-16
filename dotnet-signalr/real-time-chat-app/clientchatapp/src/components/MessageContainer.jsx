import React from 'react';

const MessageContainer = ({ messages }) => {
  return (
    <div>
      {messages.map((msg, index) => (
        <table key={index} className="striped bordered">
          <tbody>
            <tr>
              <td>{msg.userName} - {msg.msg}</td>
            </tr>
          </tbody>
        </table>
      ))}
    </div>
  );
};

export default MessageContainer;
