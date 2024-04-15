import PackageCard from "./PackageCard";
import { PackageProps } from "./../Props.ts";
import { ItemProps } from "./../Props.ts";
import Modal from "./Modal.tsx";
import { useState, useEffect } from "react";
import ItemsInfo from "./ItemsInfo.tsx";
import CloseBtn from "./CloseBtn.tsx";
import { BASE_URL } from "../urls.ts";

function ListOfCards() {
  const [openModel, setOpenModel] = useState(false);
  const [selectedItem, setSelectedItem] = useState<ItemProps[]>([]); // State to store the selected item
  const [packages, setPackages] = useState<PackageProps[]>([]);

  const handleOpenModal = (items: ItemProps[]) => {
    setOpenModel(true);
    setSelectedItem(items);
  };

  const handleCloseModal = () => {
    setOpenModel(false);
  };

  useEffect(() => {
    const fetchPackages = async () => {
      const response = await fetch(`${BASE_URL}/Package`);
      const packages_response = (await response.json()) as PackageProps[];
      setPackages(packages_response);
    };

    fetchPackages();
  }, []);
  return (
    <>
      {openModel && (
        <Modal
          title="Список предметів"
          body={<ItemsInfo items={selectedItem}></ItemsInfo>}
          footer={<CloseBtn onClose={handleCloseModal}></CloseBtn>}
        />
      )}

      <div className="container py-5">
        <div className="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-3">
          {packages.map((packageItem) => (
            <PackageCard
              onClick={handleOpenModal}
              key={packageItem.id}
              packageItem={packageItem}
            ></PackageCard>
          ))}
        </div>
      </div>
    </>
  );
}

export default ListOfCards;
