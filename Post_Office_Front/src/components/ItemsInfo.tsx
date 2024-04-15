import React from "react";
import { ItemProps } from "../Props";
interface ItemsInfoProps {
  items: ItemProps[];
}
const ItemsInfo: React.FC<ItemsInfoProps> = (items: ItemsInfoProps) => {
  return (
    <ul className="list-group mb-2">
      {items.items.map((item) => (
        <li
          className="list-group-item d-flex justify-content-between"
          key={item.name}
        >
          <span style={{ marginRight: "10px" }}>{item.name}</span>

          <span>Вага: {item.weight}</span>
        </li>
      ))}
    </ul>
  );
};

export default ItemsInfo;
