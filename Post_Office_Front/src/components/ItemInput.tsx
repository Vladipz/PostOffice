import { ItemProps } from "../Props";

interface itemCreate {
  index: number;
  items: ItemProps[];
  setItems: React.Dispatch<React.SetStateAction<ItemProps[]>>;
}

const ItemInput = ({ index, items, setItems }: itemCreate) => {
  //   console.log(items);
  return (
    <div className="input-group mb-2">
      <span className="input-group-text">Назва і вага</span>
      <input
        type="text"
        aria-label="First name"
        className="form-control"
        value={items[index].name}
        onChange={(e) =>
          setItems((Prev) => {
            Prev[index].name = e.target.value;
            return [...Prev];
          })
        }
      />
      <input
        type="text"
        aria-label="Last name"
        className="form-control"
        value={items[index].weight}
        onChange={(e) =>
          setItems((Prev) => {
            Prev[index].weight = e.target.value;
            return [...Prev];
          })
        }
      />
    </div>
  );
};

export default ItemInput;
