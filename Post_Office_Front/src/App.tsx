import { useState } from "react";
import ListOfCards from "./components/ListOfCards";
import NavBar from "./components/NavBar";
import Modal from "./components/Modal";
import CreatePackage from "./components/CreatePackage";
import CloseBtn from "./components/CloseBtn";
import Button from "./components/Button";
function App() {
  const [openModel, setOpenModel] = useState(false);
  const handleOpenModal = () => {
    setOpenModel(true);
  };

  const handleCloseModal = () => {
    setOpenModel(false);
  };
  return (
    <>
      {" "}
      {openModel && (
        <Modal
          title="Створення посилки"
          body={<CreatePackage />}
          footer={<CloseBtn onClose={handleCloseModal}></CloseBtn>}
        ></Modal>
      )}
      <NavBar
        button={
          <Button
            text="Створити посилку"
            style="btn btn-outline-success"
            onClick={handleOpenModal}
          ></Button>
        }
      ></NavBar>
      <ListOfCards></ListOfCards>
    </>
  );
}

export default App;
