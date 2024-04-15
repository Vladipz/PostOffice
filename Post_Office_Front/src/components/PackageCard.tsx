import PersonInfo from "./PersonInfo";

import { PackageCardProps } from "./../Props.ts";
import { BASE_URL } from "../urls.ts";

function formatISODate(date: Date): string {
  const year = date.getFullYear();
  const month = (date.getMonth() + 1).toString().padStart(2, "0");
  const day = date.getDate().toString().padStart(2, "0");
  return `${year}-${month}-${day}`;
}

const handleButtonSentBackClick = async (packageId: string) => {
  fetch(`${BASE_URL}/Package/${packageId}`, {
    method: "PUT",
  }).then(() => console.log("new package"));
};

const handleButtonReceiveClick = async (packageId: string) => {
  fetch(`${BASE_URL}/Package/${packageId}/Deliver`, {
    method: "PUT",
  }).then(() => console.log("new package"));
};

function PackageCard({ packageItem, onClick }: PackageCardProps) {
  return (
    <>
      <div className="col">
        <div className="card shadow-sm">
          <div className="card-header">
            <b>ID посилки: </b>
            {packageItem.id}
          </div>
          <div className="card-body">
            <div className="container">
              <PersonInfo
                info="Відправник"
                person={packageItem.sender}
              ></PersonInfo>
              <p>
                Дата відправки: {formatISODate(new Date(packageItem.sentDate))}
              </p>

              <PersonInfo
                info="Одержувач"
                person={packageItem.receiver}
              ></PersonInfo>
              <p>
                Дата доставки:{" "}
                {formatISODate(new Date(packageItem.deliveryDate))}
                <p>
                  Статус:{" "}
                  {packageItem.deliveryStatus == 0 ? "Відправлено" : "Одержано"}
                </p>
              </p>
            </div>
            <div className="d-flex justify-content-between align-items-center">
              <div className="btn-group">
                <button
                  type="button"
                  className="btn btn-sm btn-outline-secondary"
                  onClick={() => handleButtonReceiveClick(packageItem.id)}
                >
                  Отримати
                </button>
                <button
                  type="button"
                  className="btn btn-sm btn-outline-secondary"
                  onClick={() => handleButtonSentBackClick(packageItem.id)}
                >
                  Повернути
                </button>
                <button
                  type="button"
                  className="btn btn-sm btn-outline-secondary"
                  onClick={() => onClick(packageItem.items)}
                >
                  Предмети
                </button>
              </div>
              <small className="text-muted">{packageItem.distance} км</small>
              <small className="text-muted">
                {packageItem.deliveryCost} грн
              </small>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

export default PackageCard;
