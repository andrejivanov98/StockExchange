import React, { useState, useEffect } from 'react';
import './order.styles.css';
import { StockModel } from '../../models/stock';
import { getAllStocks, getStockDetails } from '../../services/stock-service';
import { OrderCreate, OrderPreview, OrderPreviewModel } from '../../models/order';
import { createOrder, previewOrder } from '../../services/order-service';
import { getUserDetails } from '../../services/user-service';

const OrderComponent = () => {
  const [stocks, setStocks] = useState<StockModel[]>([]);
  const [selectedStock, setSelectedStock] = useState<StockModel | null>(null);
  const [quantity, setQuantity] = useState<number>(0);
  const [totalCost, setTotalCost] = useState<number>(0);
  const [cashBalance, setCashBalance] = useState<number | undefined>(undefined);
  const [accountId, setAccountId] = useState<string | null>(null);
  const [showReviewModal, setShowReviewModal] = useState<boolean>(false);
  const [reviewData, setReviewData] = useState<OrderPreviewModel | null>(null);
  const [showConfirmationModal, setShowConfirmationModal] = useState<boolean>(false);
  const [confirmationMessage, setConfirmationMessage] = useState<string>('');
  const [messageColor, setMessageColor] = useState<string>('black');

  const loggedUserId = '40cf0867-c2cc-4aab-9ef7-f40590791dee';

  useEffect(() => {
    getAllStocks().then(response => {
      setStocks(response.data);
      if (response.data.length > 0) {
        setSelectedStock(response.data[0]);
      }
    });

    getUserDetails(loggedUserId).then(response => {
      setAccountId(response.data.accountId);
      setCashBalance(response.data.cashBalance);
    });
  }, []);

  useEffect(() => {
    if (selectedStock && quantity > 0) {
      setTotalCost(selectedStock.currentPrice * quantity);
    } else {
      setTotalCost(0);
    }
  }, [selectedStock, quantity]);

  const handleStockChange = async (event: React.ChangeEvent<HTMLSelectElement>) => {
    const stockId = event.target.value;
    const stock = stocks.find(s => s.id === stockId);
  
    if (stock) {
      try {
        const details = await getStockDetails(stock.id);
        setSelectedStock({ ...stock, currentPrice: details.data.currentPrice });
      } catch (error) {
        console.error("Error fetching stock details:", error);
      }
    } else {
      setSelectedStock(null);
    }    
  };

  const handleQuantityChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    let qty = parseInt(event.target.value);
    qty = isNaN(qty) ? 0 : qty < 0 ? 0 : qty;
    setQuantity(qty);
  };

  const handleReviewOrder = async () => {
    if (selectedStock && accountId) {
      const preview: OrderPreview = {
        stockId: selectedStock.id,
        numberOfShares: quantity,
        accountId: accountId
      };
      const previewResponse = await previewOrder(preview);
      setReviewData(previewResponse.data);
      setShowReviewModal(true);
    }
  };

  const handleConfirmOrder = async () => {
    if (selectedStock && accountId) {
      const order: OrderCreate = {
        accountId: accountId,
        stockId: selectedStock.id,
        numberOfShares: quantity
      };
      try {
        const orderResponse = await createOrder(order);
        setConfirmationMessage('Successful order!');
        setMessageColor('green');
        setShowConfirmationModal(true);
        setQuantity(0);
        setTotalCost(0);
        setCashBalance(orderResponse.data.updatedCashBalance);
      } catch (error) {
        setConfirmationMessage('Insufficient funds to place the order.');
        setMessageColor('red');
        setShowConfirmationModal(true);
      }
      setShowReviewModal(false);
    }
  };
  

  return (
    <div className="order-component">
      <h2>Make a Stock Order</h2>
      {typeof cashBalance === 'number' ? (
        <p>Cash Balance: <span className="cash-balance">${cashBalance.toFixed(2)}</span></p>
      ) : (
        <p>Loading Cash Balance...</p>
      )}
      <div>
        <label>Stock Name:</label>
        <select onChange={handleStockChange}>
          {stocks.map(stock => (
            <option key={stock.id} value={stock.id}>{stock.name}</option>
          ))}
        </select>
      </div>
      <div>
        <label>Stocks Quantity:</label>
        <input type="number" value={quantity} onChange={handleQuantityChange} />
      </div>
      <div>
        <label>Total Cost:</label>
        <input type="text" value={totalCost} readOnly />
      </div>
      <button onClick={handleReviewOrder} className="order-button">Review Order</button>
      {showReviewModal && (
        <div className="modal">
          <h3>Order Preview</h3>
          <p>Stock: {reviewData?.stockName}</p>
          <p>Quantity: {reviewData?.numberOfShares}</p>
          <p>Total Cost: ${reviewData?.totalCost}</p>
          <p>Valid Order: <span className={reviewData?.isOrderValid ? 'valid-order-yes' : 'valid-order-no'}>{reviewData?.isOrderValid ? "Yes" : "No"}</span></p>
          <button onClick={handleConfirmOrder} className="modal-confirm-button">Confirm Order</button>
          <button onClick={() => setShowReviewModal(false)} className="modal-close-button">Close</button>
        </div>
      )}
      {showConfirmationModal && (
        <div className="modal">
          <p style={{ color: messageColor }}>{confirmationMessage}</p>
          <button onClick={() => setShowConfirmationModal(false)} className="modal-close-button">Close</button>
        </div>
      )}
    </div>
  );
};

export default OrderComponent;
