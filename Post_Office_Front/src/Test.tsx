// MyButton.jsx
import React from 'react';

const MyButton = ({ onClick }) => {
    return (
        <button onClick={onClick}>
            Send Request
        </button>
    );
};

export default MyButton;
