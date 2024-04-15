import { useState } from "react";
import Button from "./Button";
import PersonInfoInput from "./PersonInfoInput";
import ItemInput from "./ItemInput";
import { CreatePackageProps, ItemProps, PersonProps } from "../Props";
import { BASE_URL } from "../urls";

const CreatePackage = () => {
  const [senderInfo, setSenderInfo] = useState<PersonProps>({
    name: "",
    address: "",
    phoneNumber: "",
  });

  const [receiverInfo, setReceiverInfo] = useState<PersonProps>({
    name: "",
    address: "",
    phoneNumber: "",
  });

  const [itemInputs, setItemInputs] = useState<ItemProps[]>([]);

  const addNewItemInput = () => {
    setItemInputs((prevItemInputs) => [
      ...prevItemInputs,
      { name: "", weight: 0 },
    ]);
  };

  const handleSenderInfoChange = (newSenderInfo: PersonProps) => {
    setSenderInfo(newSenderInfo);
  };
  const handleReceiverInfoChange = (newReceiverInfo: PersonProps) => {
    setReceiverInfo(newReceiverInfo);
  };

  const handleSendButtonClick = () => {
    const createPackageProps: CreatePackageProps = {
      sender: senderInfo,
      receiver: receiverInfo,
      items: itemInputs,
    };

    fetch(`${BASE_URL}/Package`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(createPackageProps),
    }).then(() => console.log("new package"));
  };

  return (
    <>
      <form>
        <div className="form-group">
          <PersonInfoInput
            info="Відправник"
            onChange={handleSenderInfoChange}
            value={senderInfo}
          ></PersonInfoInput>
          <PersonInfoInput
            info="Отримувач"
            onChange={handleReceiverInfoChange}
            value={receiverInfo}
          ></PersonInfoInput>
        </div>
      </form>

      {itemInputs.map((itemInput, index) => (
        <div key={index}>
          <ItemInput
            setItems={setItemInputs}
            items={itemInputs}
            index={index}
          />
        </div>
      ))}

      <Button
        onClick={addNewItemInput}
        style="btn btn-secondary btn-lg col-12 mg-2"
        text="Додати 📦"
      />
      <Button
        onClick={handleSendButtonClick}
        style="btn btn-outline-success btn-lg col-12 "
        text="Відправити 📦"
      />
    </>
  );
};

export default CreatePackage;
