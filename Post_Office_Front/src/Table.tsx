// MyComponent.jsx
import React, { useEffect, useState } from 'react';

const MyComponent = () => {
    const [data, setData] = useState([]);

    useEffect(() => {
        // Функція для виклику API та оновлення стану з отриманими даними
        const fetchData = async () => {
            try {
                const response = await fetch('http://localhost:5125/api/person');
                const responseData = await response.json();
                setData(responseData);
            } catch (error) {
                console.error('Error:', error);
            }
        };

        // Викликаємо функцію при монтажі компонента
        fetchData();
    }, []); // Передаємо пустий масив, щоб ефект викликався лише раз під час монтажу

    return (
        <table>
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Column 1</th>
                    <th>Column 2</th>
                    <th>Column 3</th>
                </tr>
            </thead>
            <tbody>
                {data.map((item: any) => (
                    <tr key={item.id}>
                        <td>{item.id}</td>
                        <td>{item.name}</td>
                        <td>{item.address}</td>
                        <td>{item.phoneNumber}</td>
                    </tr>
                ))}
            </tbody>
        </table>
    );
};

export default MyComponent;
